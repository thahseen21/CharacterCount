using Api.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Api.Middleware
{
    // Global exception handling middleware to avoid any unhandled errors
    // Can implement logger to maintain logs
    public class ExceptionHandler
    {
        private RequestDelegate _next;

        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public RequestDelegate RequestDelegate { get; }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            HttpResponse response = context.Response;
            response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();

            string message = "Something Went Wrong, Contact Admin";

            switch (ex)
            {
                case NotImplementedException:
                    response.StatusCode = HttpStatusCode.NotImplemented.GetHashCode();
                    break;
                case ArgumentException:
                    message = ex.Message;
                    break;
                case ValidationException:
                    message = ex.Message;
                    break;
            }
            await response.WriteAsync(
                JsonConvert.SerializeObject(
                    new ErrorDetails { Message = message, Status = response.StatusCode }
                )
            );
        }
    }
}
