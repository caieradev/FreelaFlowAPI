using System.Security.Claims;
using FreelaFlowApi.Application.Exceptions;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.Services;
public abstract class BaseService(IHttpContextAccessor httpContextAccessor)
{        
    protected readonly IEnumerable<Claim>? _userSession = httpContextAccessor.HttpContext?.User.Claims;

    protected T GetUserSessionClaim<T>(ClaimEnum claimEnum)
    {
        var claim = _userSession?.FirstOrDefault(claim => claimEnum.ToString() == claim.Type) ??
            throw new DebugMessageException("Verificar sessão do usuário");

        return (T)Convert.ChangeType(claim.Value, typeof(T));
    }

    protected Guid GetUserId() => GetUserSessionClaim<Guid>(ClaimEnum.IUId);
}