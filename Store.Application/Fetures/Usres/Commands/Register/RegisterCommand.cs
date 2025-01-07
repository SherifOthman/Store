using MediatR;
using Store.Application.Responses;

namespace Store.Application.Fetures.Usres.Commands.Register;
public class RegisterCommand : IRequest<BaseResult>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

}
