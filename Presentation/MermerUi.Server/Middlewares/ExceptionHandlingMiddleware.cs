using MermerUi.Application.ResponseModels;
using Newtonsoft.Json;

namespace MermerUi.Server.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private static ILogger<ExceptionHandlingMiddleware> loggerFactory;
        public ExceptionHandlingMiddleware(RequestDelegate Next, ILogger<ExceptionHandlingMiddleware> Logger)
        {
            next = Next;
            loggerFactory = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                loggerFactory.LogError(ex, "Request Error");
                httpContext.Response.StatusCode = 200;
                httpContext.Response.ContentType = "application/json";
                var response = new ServiceResponse<string>();
                response.SetException(ex);
                var json = JsonConvert.SerializeObject(response);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
