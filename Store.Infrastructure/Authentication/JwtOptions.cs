using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Authentication;
public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SecurityKey { get; set; } = string.Empty;
    public int TokenLifeTime { get; set; }
    public int RefreshTokenLifeTime { get; set; }

}
