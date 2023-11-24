using Schoolme.Common.Aggregates;
using Schoolme.Common.Entities;
using Schoolme.Domain.Entities;
using Schoolme.Domain.ValueObjects;

namespace Schoolme.Domain.Aggregates;

public sealed class Student : AggregateRoot, IAuditEntity
{
    private ICollection<CourseEnrollment> _courses;
    
    public string FirstName { get; private set; } = default!;
    
    public string LastName { get; private set; } = default!;
    
    public string? MiddleName { get; private set; }
    
    public PeselNumber PeselNumber { get; private set; } = default!;
    
    public HomeAddress HomeAddress { get; private set; } = default!;
    
    // Audit
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
    
    public IReadOnlyCollection<CourseEnrollment> Courses => _courses.ToList().AsReadOnly();
    
    public void EnrollToCourse(Course? course)
    {
        if (course is null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        if (UserIsAlreadyEnrolledForCourse(course.Id))
        {
            throw new InvalidOperationException($"Student {Id} is already enrolled for course {course.Id}");
        }
        
        _courses.Add(new CourseEnrollment(course.Id, Id));
        
        AddDomainEvent(new StudentEnrolledToCourseDomainEvent(Id, course.Id));
        IncrementVersion();
    }
    
    private bool UserIsAlreadyEnrolledForCourse(Guid courseId)
    {
        return _courses.Any(x => x.CourseId == courseId);
    }
}

public sealed record StudentEnrolledToCourseDomainEvent(
    Guid StudentId,
    Guid CourseId)
    : DomainEvent;