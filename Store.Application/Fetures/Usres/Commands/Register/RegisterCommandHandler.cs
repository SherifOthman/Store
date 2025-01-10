
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Contracts.Persistence;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Application.Responses;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;
using Store.Domain.FixedValues;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResult>
{
    private readonly IMapper _mapper;
    private readonly IUserManager _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(IMapper mapper, IUserManager userManager,
        IUnitOfWork unitOfWork, IPasswordHasher passwordHasher,
        ILogger<RegisterCommandHandler> logger, ILoggedInService loggedInService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<BaseResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.IsEmailExistsAsync(request.Email, cancellationToken))
        {
            return BaseResult.FailureWithMessage("Email is already Exists");
        }

        var defaultRole = await _unitOfWork.Roles.GetByNameAsync(RoleValues.DefaultRole, cancellationToken);       
        
        if (defaultRole == null)
        {
            _logger.LogError("Table Roles in database doesn't have {@DefaultRole}", RoleValues.DefaultRole);
            throw new InvalidOperationException("The default role could not be found.");
        }

        var user = _mapper.Map<User>(request);

        user.Roles.Add(defaultRole);
        var result = await _userManager.AddUserAsync(user, cancellationToken);

        return (result.Succceeded) ?
            BaseResult.Success() : BaseResult.FailureWithMessage("Unexpected Eror");
    }
}
