using Microsoft.EntityFrameworkCore;
using Schoolme.Infrastructure.Outbox.Configurations;
using Schoolme.Infrastructure.Outbox.Entities;

namespace Schoolme.Infrastructure.Outbox;

public static class Extensions
{
    public static ModelBuilder ApplyOutboxConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OutboxEventEntityTypeConfiguration());
        
        return modelBuilder;
    }
    
    public static IServiceCollection AddOutbox(this IServiceCollection services,
        IConfiguration configuration)
    {
        OutboxOptions options = new();
        configuration.GetSection(OutboxOptions.Name).Bind(options);
        
        services.AddDbContext<OutboxDbContext>(opts =>
        {
            if (options.UseInMemory)
            {
                opts.UseInMemoryDatabase(OutboxOptions.Name);
            }
            else
            {
                opts.UseSqlServer(
                    configuration.GetConnectionString(OutboxOptions.Name),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsHistoryTable(
                            OutboxOptions.EfHistoryTableName,
                            OutboxOptions.SchemaName);
                    });
            }
        });
        
        return services;
    }
}