using Todo.API.ExceptionModel;
using Todo.Application.Exceptions;

namespace Todo.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                this.next(context);
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
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = e.Message
                });
            }
        }
    }
}
