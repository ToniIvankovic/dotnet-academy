using System.Text.Json;
using Library.ToniIvankovic.Contracts.Exceptions;

namespace Library.ToniIvankovic.Api
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await OnException(context, ex);
            }
        }

        private async Task OnException(HttpContext context, Exception error)
        {
            object response;
            _ = error switch
            {
                BookNotAvailableException =>
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound,
                EntityNotFoundException =>
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound,
                EntityAlreadyExistsException =>
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.Conflict,
                UserAuthenticationException =>
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized,
                BookRentingException =>
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest,
                InvalidFieldsException =>
                    context.Response.StatusCode= (int)System.Net.HttpStatusCode.BadRequest,

            _ => context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
            };

            response = new
            {
                error.Message
            };
            context.Response.ContentType = "application/json";

            var resultJson = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(resultJson);
        }
    }
}
