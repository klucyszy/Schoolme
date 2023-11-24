using Schoolme.Application.Students;
using Schoolme.Domain.Entities;

namespace Schoolme.Infrastructure.Students.Repositories;

internal sealed class CourseRepository : ICoursesRepository
{
    public async Task<Course?> GetAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}