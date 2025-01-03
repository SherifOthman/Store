using AutoMapper;
using MediatR;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Persistence;
using Store.Application.Exceptions;

namespace Store.Application.Fetures.Usres.Commands.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
        IJwtProvider jwtProvider)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;

    }


    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByEmailAndPassword(request.Email, request.Password);

        if (user == null)
            throw new InvalidCredentialsException();

        // Generate JWT
        string token = _jwtProvider.GenerateAccessToken(user);

        return new LoginCommandResponse
        {
            Token = token
        };
    }

}
