using System.Net;

namespace FinApp.API.Middlewares {
    public class ExceptionHandlerMiddleware {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await next(httpContext);
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();

                //log exception
                logger.LogError(ex, $"{errorId} : {ex.Message}");

                //custom errror merssage
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync(new {
                    Title = "Server error",
                    Id = errorId,
                    ErrorMessage = "An error occured."
                });
            }
        }
    }
}
