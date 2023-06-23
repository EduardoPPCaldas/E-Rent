using Application.Responses;

namespace Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ErrorResponseException e)
        {
            var response = new ErrorResponse
            {
                Error = e.Error,
                HttpStatusCode = e.HttpStatusCode,
                ErrorDetails = e.ErrorDetails,
                Timestamp = e.Timestamp
            };
            await Results.Json(response, statusCode: (int) e.HttpStatusCode)
                .ExecuteAsync(context);
        }
    }
}
