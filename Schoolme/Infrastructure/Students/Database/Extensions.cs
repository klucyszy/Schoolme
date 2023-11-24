using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Schoolme.Application.Students;
using Schoolme.Common.Database;
using Schoolme.Infrastructure.Students.Database.Configurations;

namespace Schoolme.Infrastructure.Students.Database;

public static class Extensions
{
    public static IServiceCollection AddStudentsDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        StudentsOptions options = new();
        configuration.GetSection(StudentsOptions.Name).Bind(options);
        
        services.AddDbContext<StudentsDbContext>(opts =>
        {
            if (options.UseInMemoryOutbox)
            {
                opts.UseInMemoryDatabase(StudentsOptions.Name);
            }
            else
            {
                opts.UseSqlServer(
                    configuration.GetConnectionString(StudentsOptions.Name),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsHistoryTable(
                            StudentsOptions.EfHistoryTableName,
                            StudentsOptions.SchemaName);
                    });
            }
        });
        
        services.TryAddScoped<IStudentsUnitOfWork, UnitOfWork>();
        
        return services;
    }
}