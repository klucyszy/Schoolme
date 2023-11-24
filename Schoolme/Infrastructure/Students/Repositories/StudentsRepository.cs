using Schoolme.Application.Students;
using Schoolme.Domain.Aggregates;

namespace Schoolme.Infrastructure.Students.Repositories;

internal sealed class StudentsRepository : IStudentsRepository
{
    public async Task<Student?> GetAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}