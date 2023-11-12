namespace Schoolme.Common.Responses.Endpoints;

public static class EndpointResponseToResultsMapper
{
    public static IResult ToMinimalApiResultsResponse(this EndpointResponse response)
    {
        return response.Code switch
        {
            StatusCodes.Status200OK => Results.Ok(),
            StatusCodes.Status201Created => Results.Created("api/students/todo", null),
            StatusCodes.Status204NoContent => Results.NoContent(),
            >= 400 => Results.Problem(
                title: response.ErrorMessage ?? "Something went wrong",
                statusCode: response.Code
                ),
            _ => throw new ArgumentOutOfRangeException(nameof(response), response, null)
        };
    }
    
    public static IResult ToMinimalResultsResponse<TData>(this EndpointResponse<TData> response)
        where TData : class

    {
        return response.Code switch
        {
            StatusCodes.Status200OK => Results.Ok(response.Data),
            StatusCodes.Status201Created => Results.Created(string.Empty, response.Data),
            >= 400 => Results.Problem(
                title: response.ErrorMessage ?? "Something went wrong",
                statusCode: response.Code
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(response), response, null)
        };
    }
}