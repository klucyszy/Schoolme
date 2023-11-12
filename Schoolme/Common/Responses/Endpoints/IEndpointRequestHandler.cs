using MediatR;

namespace Schoolme.Common.Responses.Endpoints;

public interface IEndpointRequestHandler<in TRequest> : IRequestHandler<TRequest, EndpointResponse>
    where TRequest : IEndpointRequest
{
}

public interface IEndpointRequestHandler<in TRequest, TData> : IRequestHandler<TRequest, EndpointResponse<TData>>
    where TRequest : IEndpointRequest<TData>
    where TData : class
{
}