
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.Application.Contracts.Infrastructure;
using Store.Application.Contracts.Persistence;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Application.Responses;
using Store.Domain.Entities.Users;
using Store.Domain.FixedValues;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResult>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher, ILogger<RegisterCommandHandler> logger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }
    public async Task<BaseResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.Users.GetByEmailAsync(request.Email) != null)
        {
            return BaseResult.FailureWithMessage("Email is already Exists");
        }

        var defaultRole = await _unitOfWork.Roles.GetByNameAsync(RoleValues.DefaultRole);

        if (defaultRole == null)
        {
            _logger.LogError("Table Roles in database doesn't have {@DefaultRole}", RoleValues.DefaultRole);
            throw new InvalidOperationException("The default role could not be found.");
        }

        var user = _mapper.Map<User>(request);
        user.PasswordHashed = _passwordHasher.HashPassword(request.Password);
        user.Roles.Add(defaultRole);

        await _unitOfWork.Users.AddAsync(user);
        int affectedRows = await _unitOfWork.CompleteAsync();

        if (affectedRows > 0)
            return BaseResult.Success();
        else

            return BaseResult.FailureWithMessage("Something went worng while registering account");
    }
}
