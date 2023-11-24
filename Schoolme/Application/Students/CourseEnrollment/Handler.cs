using Schoolme.Common.Database;
using Schoolme.Common.Responses.Endpoints;
using Schoolme.Domain.Aggregates;
using Schoolme.Domain.Entities;
using Schoolme.Infrastructure.Students.Database;
using System.Net;

namespace Schoolme.Application.Students.CourseEnrollment;

public sealed record EnrollStudentInCourseCommand(
    Guid StudentId,
    Guid CourseEnrollmentId
) : IEndpointRequest;

public class EnrollStudentInCourseCommandHandler : IEndpointRequestHandler<EnrollStudentInCourseCommand>
{
    private readonly IStudentsRepository _studentsRepository;
    private readonly ICoursesRepository _coursesRepository;
    private readonly IStudentsUnitOfWork _unitOfWork;

    public EnrollStudentInCourseCommandHandler(IStudentsRepository studentsRepository,
        ICoursesRepository coursesRepository, IStudentsUnitOfWork unitOfWork)
    {
        _studentsRepository = studentsRepository;
        _coursesRepository = coursesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EndpointResponse> Handle(
        EnrollStudentInCourseCommand request,
        CancellationToken cancellationToken)
    {
        if (request.StudentId == Guid.Empty)
        {
            return EndpointResponse.Failure(HttpStatusCode.BadRequest, "Student ID is required.");
        }
        
        Student? student = await _studentsRepository
            .GetAsync(request.StudentId, cancellationToken);

        if (student is null)
        {
            return EndpointResponse.Failure(HttpStatusCode.NotFound, $"Student {request.StudentId} does not exist.");
        }
        
        Course? course = await _coursesRepository
            .GetAsync(request.CourseEnrollmentId, cancellationToken);

        if (course is null)
        {
            return EndpointResponse.Failure(HttpStatusCode.NotFound, $"Course {request.CourseEnrollmentId} does not exist.");
        }
        
        student.EnrollToCourse(course);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return EndpointResponse.Success(HttpStatusCode.Created);
    }
}