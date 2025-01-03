using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Infrastructure.Authentication;
public interface ILoggedInService
{
    int UserId { get; }
    string? IpAddress { get; }
}
