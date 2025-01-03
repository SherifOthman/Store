using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Responses;
public class Result<T> : Result
{
    public T? Data { get; private set; }

    public static Result<T> Success(T data, string message = "")
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message,
        };
    }

    public static Result<T> Failure(string message,
        IDictionary<string, string[]>? validationErrors = null!)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            ValidationErrors = validationErrors
        };
    }

    public static Result<T> Failure(IDictionary<string, string[]> validationErrors)
    {
        return new Result<T>
        {
            IsSuccess = false,
            ValidationErrors = validationErrors,
        };
    }


    // Overload operators 

    public static implicit operator Result<T>(T data)
    {
        return Success(data);
    }

    public static implicit operator Result<T>(string message)
    {
        return Result<T>.Failure(message);
    }


}
