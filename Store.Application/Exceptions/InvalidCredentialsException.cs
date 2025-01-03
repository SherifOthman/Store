using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Exceptions;
public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException(string message) 
        : base(message)
    {
        
    }

    public InvalidCredentialsException()
        : base("Invalid email or passowrd")
    {
        
    }
}
