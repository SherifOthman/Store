using MediatR;
using Store.Domain.Entities.Users;
using System.Windows.Input;


namespace Store.Application.Fetures.Usres.Commands.Login;


public record LoginCommand(string Email, string Password) : IRequest<LoginCommandResponse>;

