using Schoolme.Common.Responses.Endpoints;
using System.Net;

namespace Schoolme.Presentation.Students.CourseEnrollment;

public sealed record EnrollStudentInCourseCommand(
    Guid StudentId,
    Guid CourseEnrollmentId
) : IEndpointRequest;

public class EnrollStudentInCourseCommandHandler : IEndpointRequestHandler<EnrollStudentInCourseCommand>
{
    public async Task<EndpointResponse> Handle(
        EnrollStudentInCourseCommand request,
        CancellationToken cancellationToken)
    {
        if (request.StudentId == Guid.Empty)
        {
            return EndpointResponse.Failure(HttpStatusCode.BadRequest, "Student ID is required.");
        }
        
        return EndpointResponse.Success(HttpStatusCode.Created);
    }
}