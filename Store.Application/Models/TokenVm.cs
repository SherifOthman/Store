using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models;
public class TokenVm
{
    public required string Token { get; set; }
    public required DateTime ExpiresIn { get; set; }
}
