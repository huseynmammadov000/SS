using Microsoft.AspNetCore.Http;
using StartupShopping.Application.Abstractions.Auth;

public class SessionValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthService _authService;

    public SessionValidationMiddleware(RequestDelegate next, IAuthService authService)
    {
        _next = next;
        _authService = authService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
    //    var sessionCookie = context.Request.Cookies["session"];
    //    var refreshTokenCookie = context.Request.Cookies["refreshToken"];

    //    if (!string.IsNullOrEmpty(sessionCookie) && !string.IsNullOrEmpty(refreshTokenCookie))
    //    {
    //        var clientUserAgent = context.Request.Headers["User-Agent"].ToString();
    //        var clientRealIp = context.Connection.RemoteIpAddress?.ToString();

    //        try
    //        {
    //            await _authService.ValidateAsync(sessionCookie, clientUserAgent, clientRealIp);

    //            var session = await _authService.GetSessionAsync(sessionCookie);

    //            if (session.ExpiredAt < DateTime.UtcNow)
    //            {
    //                // Session expired, check refresh token
    //                var newSession = await _authService.RefreshSessionAsync(refreshTokenCookie, clientUserAgent, clientRealIp);
    //                if (newSession != null)
    //                {
    //                    // Set new session cookie
    //                    context.Response.Cookies.Append("session", newSession.Id);
    //                }
    //                else
    //                {
    //                    // Refresh token invalid
    //                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //                    return;
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            return;
    //        }
    //    }

    //    await _next(context);
    }
}
