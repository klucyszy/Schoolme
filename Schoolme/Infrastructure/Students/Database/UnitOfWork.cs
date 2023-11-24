using Schoolme.Application.Students;
using Schoolme.Common.Database;

namespace Schoolme.Infrastructure.Students.Database;

internal sealed class UnitOfWork : IStudentsUnitOfWork
{
    private readonly StudentsDbContext _dbContext;

    public UnitOfWork(StudentsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}