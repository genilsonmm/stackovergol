using Microsoft.AspNetCore.Mvc;
using stackovergol.Exceptions;

namespace stackovergol.Middlewares
{
    public class GlobalExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next, 
            ILogger<GlobalExceptionMiddleware> logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ProblemDetails problem = ProblemDetailsFactory(StatusCodes.Status500InternalServerError, "Erro interno");

                switch (ex)
                {
                    case NotFoundException:
                        problem = ProblemDetailsFactory(StatusCodes.Status204NoContent, ex.Message);
                        break;
                    case DuplicateException:
                        problem = ProblemDetailsFactory(StatusCodes.Status400BadRequest, ex.Message);
                        break;
                     default:
                        problem = ProblemDetailsFactory(StatusCodes.Status500InternalServerError, ex.Message);
                        break;
                }
                
               
                await context.Response.WriteAsJsonAsync(problem);
            }
        }

        private ProblemDetails ProblemDetailsFactory(int status, string message)
        {
            return new()
            {
                Status = status,
                Type = "Server error",
                Title = "Error",
                Detail = message
            };
        }
    }
}
