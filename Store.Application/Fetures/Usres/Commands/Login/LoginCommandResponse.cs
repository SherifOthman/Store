using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Fetures.Usres.Commands.Login;
public class LoginCommandResponse
{
    public string Token { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }

}
