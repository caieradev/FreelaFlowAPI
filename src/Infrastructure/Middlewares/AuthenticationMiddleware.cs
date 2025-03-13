using FirebaseAdmin.Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
using FreelaFlowApi.Application.Attributes;

namespace FreelaFlowApi.Infrastructure.Middlewares;
public class AuthenticationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

        EndpointMetadataCollection? metadata = context.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata;
        bool skipAuthentication = metadata?.GetMetadata<SkipAuthenticationAttribute>() != null;
        bool optionalAuthentication = metadata?.GetMetadata<OptionalAuthenticationAttribute>() != null;

        var path = context.Request.Path.Value?.ToLower();
        if (path != null && (path.Contains("swagger") || path.StartsWith("/api-docs")))
        {
            await _next(context);
            return;
        }

        if (skipAuthentication)
        {
            await _next(context);
            return;
        }

        if (optionalAuthentication && string.IsNullOrEmpty(authorizationHeader))
        {
            await _next(context);
            return;
        }

        if (authorizationHeader == null || !authorizationHeader.StartsWith("Bearer "))
        {
            if (!optionalAuthentication)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            await _next(context);
            return;
        }

        var idToken = authorizationHeader.Substring("Bearer ".Length).Trim();

            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                var claims = decodedToken.Claims
                    .Where(x => x.Value != null)
                    .Select(x => new Claim(x.Key, x.Value.ToString()!));

                var claimsIdentity = new ClaimsIdentity(claims, "Firebase");
                context.User = new ClaimsPrincipal(claimsIdentity);
            }
            catch
            {
                if (!optionalAuthentication)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }

        await _next(context);
    }
}
