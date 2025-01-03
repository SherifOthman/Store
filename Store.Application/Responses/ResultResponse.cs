
namespace Store.Application.Responses;

public class Result
{
    public bool IsSuccess { get; protected set; }
    public string? Message { get; protected set; }
    public IDictionary<string, string[]>? ValidationErrors { get; protected set; }

}
