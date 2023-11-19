using Schoolme.Common.Entities;

namespace Schoolme.Domain.Entities;

public sealed class Course
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
}