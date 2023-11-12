using Microsoft.EntityFrameworkCore;
using Schoolme.Infrastructure.Outbox.Configurations;

namespace Schoolme.Infrastructure.Outbox;

public static class Extensions
{
    public static IServiceCollection AddOutbox(this IServiceCollection services,
        IConfiguration configuration)
    {
        OutboxOptions outboxOptions = new();
        configuration.GetSection(OutboxOptions.Name).Bind(outboxOptions);
        
        services.AddDbContext<OutboxDbContext>(options =>
        {
            if (outboxOptions.UseInMemoryOutbox)
            {
                options.UseInMemoryDatabase(OutboxOptions.Name);
            }
            else
            {
                options.UseSqlServer(
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