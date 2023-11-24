using Schoolme.Domain.Entities;

namespace Schoolme.Application.Students;

public interface ICoursesRepository
{
    Task<Course?> GetAsync(Guid courseId, CancellationToken cancellationToken = default);
}