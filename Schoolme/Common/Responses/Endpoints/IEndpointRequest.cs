using MediatR;

namespace Schoolme.Common.Responses.Endpoints;

public interface IEndpointRequest : IRequest<EndpointResponse>
{
}

public interface IEndpointRequest<TData> : IRequest<EndpointResponse<TData>>
    where TData : class
{
}