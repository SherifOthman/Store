using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Exceptions;
public class ValidationException : Exception
{
    public IDictionary<string, string[]> ValidationErrors { get; }

    public ValidationException(IDictionary<string, string[]> validationErrors)
    {
        ValidationErrors = validationErrors;
    }



}
