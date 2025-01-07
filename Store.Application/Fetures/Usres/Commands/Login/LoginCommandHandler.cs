using AutoMapper;
using MediatR;
using Store.Application.Contracts.Infrastructure;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Persistence;
using Store.Application.Exceptions;
using Store.Application.Responses;

namespace Store.Application.Fetures.Usres.Commands.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;

    public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
        IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
    }


    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHashed))
            return Result<LoginCommandResponse>.FailureWithMessage("Invalid email or password");

        var accessToken = _jwtProvider.GenerateAccessToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();



        return new LoginCommandResponse
        {
            AccessToken = accessToken.Token,
            ExpiresIn = accessToken.ExpiresIn,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresIn = refreshToken.ExpiresIn
        };

    }

}
