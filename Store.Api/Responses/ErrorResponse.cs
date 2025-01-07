using Microsoft.AspNetCore.Http.HttpResults;

namespace Store.Api.Responses;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public object? Errors { get; set; }
}
