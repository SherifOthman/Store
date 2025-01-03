namespace Store.Api.Extentions;

public static class HttpContextExtentions
{
    public static string? GetClientApiAddress(this HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress?.ToString();

        if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
        {
            ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        }

        return ipAddress;
    }
}
