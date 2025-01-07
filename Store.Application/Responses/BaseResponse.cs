
namespace Store.Application.Responses;

public class BaseResult
{
    public bool IsSuccess { get; set; }
    public bool IsFaliure => !IsSuccess;
    public string? Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }

    public static BaseResult Success()
    {
        return new BaseResult
        {
            IsSuccess = true
        };
    }

    public static BaseResult FailureWithMessage(string message)
    {
        return new BaseResult
        {
            IsSuccess = false,
            Message = message,
        };
    }

    public static BaseResult FailureWithErrors(IDictionary<string, string[]> errors)
    {
        return new BaseResult
        {
            IsSuccess = false,
            Errors = errors,
            Message = "Validation Error"
        };
    }

}
