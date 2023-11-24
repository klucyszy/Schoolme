using MediatR;
using Schoolme.Application.Students.CourseEnrollment;
using Schoolme.Common.Responses.Endpoints;

namespace Schoolme.Presentation.Students.EnrollToCourse;

public sealed record EnrollStudentInCourseRequest(
    Guid StudentId,
    Guid CourseEnrollmentId
);

public static class Endpoint
{
    private static string Uri = "api/students/{studentId}/course/{courseEnrollmentId}/enroll";
    
    public static void MapEnrollStudentInCourseEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(Uri, async (
                Guid studentId,
                Guid courseEnrollmentId,
                ISender sender) =>
        {
            EnrollStudentInCourseCommand command = new(
                studentId,
                courseEnrollmentId
            );

            EndpointResponse response = await sender.Send(command);
            
            return response.ToMinimalApiResultsResponse();
        })
        // TODO: Validate request
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
    }
    
    public sealed record EnrollStudentInCourseEndpointResponse(
        Guid StudentId,
        Guid CourseEnrollmentId
    );
}