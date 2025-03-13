namespace FreelaFlowApi.Application.Interfaces;

public interface IAuthClient : ITransient
{
    Task<string?> VerifyIdTokenAsync(string idToken);
    Task SetCustomClaimsAsync(string userId, Dictionary<string, object> claims);
    Task DeactivateUserAsync(string externalUserId);
    Task<IReadOnlyDictionary<string, object>> GetTokenClaims(string idToken);
    Task DeleteUserAsync(string externalUserId);
    Task ReactivateUserAsync(string externalUserId);
}
