using Schoolme.Domain.Aggregates;

namespace Schoolme.Application.Students;

public interface IStudentsRepository
{
    Task<Student?> GetAsync(Guid studentId, CancellationToken cancellationToken = default);
}