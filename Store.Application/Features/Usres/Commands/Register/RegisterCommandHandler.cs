using MediatR;
using Microsoft.Extensions.Logging;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Wrappers;
using Store.Domain.Entities.Users;
using Store.Domain.FixedValues;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber) : IRequestWrapper<Unit>;

public class RegisterCommandHandler : IHandler<RegisterCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPasswordHasher passwordHasher,
        ILogger<RegisterCommandHandler> logger)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    public async Task<Response<Unit>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsEmailExists(request.Email))
            return Response.Fail<Unit>("Email is already exists");


        var defaultRole = await _roleRepository.GetByNameAsync(RoleValues.DefaultRole, cancellationToken);

        if (defaultRole == null)
        {
            _logger.LogError("Table Roles in database doesn't have {@DefaultRole}", RoleValues.DefaultRole);
            throw new InvalidOperationException("The default role could not be found.");
        }

        var user = User.Create(request.FirstName,
            request.LastName,
            request.Email,
            _passwordHasher.HashPassword(request.Password),
            request.PhoneNumber);

        user.AddRole(defaultRole);
        await _userRepository.AddAsync(user, cancellationToken);

        return Unit.Value;
    }
}
