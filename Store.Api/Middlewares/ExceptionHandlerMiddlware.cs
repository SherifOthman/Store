using Microsoft.AspNetCore.Http;
using Store.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Store.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            var errorMessage = exception switch
            {
                ValidationException validation => JsonSerializer.Serialize(validation.ValidationErrors),
                _ => string.Empty
            };

            HttpStatusCode statusCode = exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                InvalidCredentialsException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            if(errorMessage == string.Empty)
            {
                errorMessage = exception.Message;
            }

            var result = JsonSerializer.Serialize(new { Message = errorMessage });
            return context.Response.WriteAsync(result);
        }
    }
}
