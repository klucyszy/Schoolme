using System.Net;

namespace Schoolme.Common.Responses.Endpoints;

public class EndpointResponse
{
    public int Code { get; init; }
    public bool HasData { get; init; }
    public string? ErrorMessage { get; init; }
    
    public static EndpointResponse Success(HttpStatusCode code)
    {
        return new()
        {
            Code = (int) code,
            HasData = false
        };
    }
    
    public static EndpointResponse Failure(HttpStatusCode code, string errorMessage)
    {
        return new()
        {
            Code = (int) code,
            HasData = false,
            ErrorMessage = errorMessage
        };
    }
}

public class EndpointResponse<TData> where TData : class
{
    public int Code { get; init; }
    public bool HasData { get; init; }
    public TData Data { get; init; }
    public string? ErrorMessage { get; init; }
    
    public static EndpointResponse<TData> Success(HttpStatusCode code, TData data)
    {
        return new()
        {
            Code = (int) code,
            HasData = true,
            Data = data
        };
    }
    
    public static EndpointResponse<TData> Success(HttpStatusCode code)
    {
        return new()
        {
            Code = (int) code,
            HasData = false
        };
    }
    
    public static EndpointResponse<TData> Failure(HttpStatusCode code, string errorMessage)
    {
        return new()
        {
            Code = (int) code,
            HasData = false,
            ErrorMessage = errorMessage
        };
    }
}