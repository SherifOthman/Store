
using AutoMapper;
using MediatR;
using Store.Application.Contracts.Persistence;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Application.Responses;
using Store.Domain.Entities.Users;
using Store.Domain.FixedValues;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.Users.GetByEmailAsync(request.Email) != null)
        {
            return "Email is already Exists";
        }

        var defaultRole = await _unitOfWork.Roles.GetByNameAsync(RoleValues.DefaultRole);

        if (defaultRole == null)
        {
            throw new InvalidOperationException("The default role could not be found.");
        }

        var user = _mapper.Map<User>(request);
        user.Roles.Add(defaultRole);

        await _unitOfWork.Users.AddAsync(user);
        int affectedRows = await _unitOfWork.CompleteAsync();

        return (affectedRows > 0);
    }
}
