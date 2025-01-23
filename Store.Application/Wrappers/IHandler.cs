    using MediatR;
using Store.Application.Responses;

namespace Store.Application.Wrappers;

public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, Response<TResponse>>
    where TRequest : IRequestWrapper<TResponse>
{

}

