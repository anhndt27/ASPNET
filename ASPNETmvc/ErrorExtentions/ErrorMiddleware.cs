namespace ASPNETmvc.ErrorExtentions;

public static class ErrorLoggingExtensions
{
    public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorLogging>();
    }
}
public class ErrorLogging
{
    private readonly RequestDelegate _next;
    public ErrorLogging(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace.ToString());
            context.Response.Redirect("/Home/Error");
        }
    }
}