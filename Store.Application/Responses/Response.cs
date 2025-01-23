
namespace Store.Application.Responses;

public static class Response
{
    public static Response<T> Ok<T>(T Data, string? message = null)
    {
        return new Response<T>
        {
            Error = false,
            Message = message,
            Data = Data
        };
    }

    public static Response<T> Fail<T>(string message, IDictionary<string, string[]>? errors = null)
    {
        return new Response<T>
        {
            Error = true,
            Message = message,
            Errors = errors
        };
    }

    public static Response<T> NotFound<T>() => Fail<T>("The requested resource was not found.");

}

public class Response<T>
{


    public bool Error { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public IDictionary<string, string[]>? Errors { get; set; }


    //  Overload operators

    public static implicit operator Response<T>(T data)
    {
        return Response.Ok(data);
    }

}

