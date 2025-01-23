using MediatR;
using Store.Application.Responses;

namespace Store.Application.Wrappers;
public interface IRequestWrapper<TResponse> : IRequest<Response<TResponse>>
{

}

