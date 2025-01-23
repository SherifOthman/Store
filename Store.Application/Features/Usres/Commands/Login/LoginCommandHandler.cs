using MediatR;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.Services;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Validations;
using Store.Application.Wrappers;
using Store.Domain.Entities.Users;

namespace Store.Application.Features.Users.Commands.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequestWrapper<TokenResponse>;


public class LoginCommandHandler : IHandler<LoginCommand, TokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<Response<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.HashedPassword))
            return Response.Fail<TokenResponse>(Message.InvalidCredentials);


        var token = await _tokenService.GenerateTokensAsync(user!, cancellationToken);

        return token;
    }
}
