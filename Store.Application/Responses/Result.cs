
namespace Store.Application.Responses;
public class Result<T> : BaseResult
{
    public T? Value { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Value = data,
        };
    }

    public static new Result<T> FailureWithMessage(string message)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message
        };
    }
    public static new Result<T> FailureWithErrors(IDictionary<string, string[]> errors)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Errors = errors,
            Message = "Validation Error"
        };
    }


  //  Overload operators

    public static implicit operator Result<T>(T data)
    {
        return Success(data);
    }

}

