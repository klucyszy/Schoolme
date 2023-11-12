using Schoolme.Application;
using Schoolme.Domain;
using Schoolme.Infrastructure;
using Schoolme.Presentation;
using Schoolme.Presentation.Students.CourseEnrollment;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();

WebApplication app = builder.Build();

app.MapEnrollStudentInCourseEndpoint();

app.Run();