using Todo.API.ExceptionModel;
using Todo.Application.Exceptions;

namespace Todo.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException e)
            {
                context.Response.StatusCode = e.StatuCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = e.StatuCode,
                    Message = e.Message
                });
            }
            catch (Exception e)
            {

                context.Response.StatusCode = 500;
                _logger.LogError($"{e}\n\n\n");
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = e.Message
                });
            }
        }
    }
}
