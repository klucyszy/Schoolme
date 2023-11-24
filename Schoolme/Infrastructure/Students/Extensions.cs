using Microsoft.Extensions.DependencyInjection.Extensions;
using Schoolme.Application.Students;
using Schoolme.Infrastructure.Students.Database;
using Schoolme.Infrastructure.Students.Repositories;

namespace Schoolme.Infrastructure.Students;

public static class Extensions
{
    public static void AddStudentsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddStudentsDatabase(configuration);
        
        services.TryAddScoped<IStudentsRepository, StudentsRepository>();
        services.TryAddScoped<ICoursesRepository, CourseRepository>();
    }
}