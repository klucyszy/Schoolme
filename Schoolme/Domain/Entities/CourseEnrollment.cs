using Schoolme.Common.Entities;

namespace Schoolme.Domain.Entities;

public sealed class CourseEnrollment
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }

    public CourseEnrollment(Guid courseId, Guid studentId)
    {
        CourseId = courseId;
        StudentId = studentId;
    }
}