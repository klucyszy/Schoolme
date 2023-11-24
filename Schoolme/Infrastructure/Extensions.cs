using Schoolme.Infrastructure.Outbox;
using Schoolme.Infrastructure.Students;
using Schoolme.Infrastructure.Students.Database;

namespace Schoolme.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(Extensions).Assembly);
        });
        
        //services.AddOutbox(configuration);
        services.AddStudentsModule(configuration);
        
        return services;
    }
}