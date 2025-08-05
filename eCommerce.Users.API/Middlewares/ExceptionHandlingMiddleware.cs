namespace eCommerce.Users.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError("{Type} - {ExMessage}", ex.GetType(), ex.Message);
            if (ex.InnerException != null)
            {
                logger.LogError("{Type} - {InnerExceptionMessage}", ex.InnerException.GetType(), ex.InnerException.Message);
            }
            
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
        }
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}