
using System.Text;

public class ShortCircuitMiddleware
{
    private RequestDelegate nextDelegate;

    public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;

    public async Task Invoke(HttpContext httpContext) {
        if(httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("windows"))) 
        {
            // context.Response.StatusCode = 423;
            await httpContext.Response.WriteAsync("You are banned!", Encoding.UTF8);
        }
        else
        {
            await nextDelegate.Invoke(httpContext);
        }
    }
}