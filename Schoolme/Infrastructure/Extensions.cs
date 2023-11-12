using Schoolme.Infrastructure.Outbox;

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
        
        services.AddOutbox(configuration);
        
        return services;
    }
}