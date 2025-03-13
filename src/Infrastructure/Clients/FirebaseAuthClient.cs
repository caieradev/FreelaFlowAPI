using FirebaseAdmin.Auth;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Infrastructure.Clients;
public class FirebaseAuthClient : IAuthClient
{
    public async Task<string?> VerifyIdTokenAsync(string idToken)
    {
        try
        {
            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            return decodedToken.Uid;
        }
        catch
        {
            return null;
        }
    }

    public async Task SetCustomClaimsAsync(string userId, Dictionary<string, object> claims) =>
        await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userId, claims);

    public async Task DeactivateUserAsync(string externalUserId)
    {
        var userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(externalUserId);
    
        var updatedUser = new UserRecordArgs
        {
            Uid = userRecord.Uid,
            Disabled = true
        };

        await FirebaseAuth.DefaultInstance.UpdateUserAsync(updatedUser);
    }

    public async Task<IReadOnlyDictionary<string, object>> GetTokenClaims(string idToken) =>
        (await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken)).Claims;

    public async Task DeleteUserAsync(string externalUserId) =>
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(externalUserId);

    public async Task ReactivateUserAsync(string externalUserId)
    {
        var userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(externalUserId);
    
        var updatedUser = new UserRecordArgs
        {
            Uid = userRecord.Uid,
            Disabled = false
        };

        await FirebaseAuth.DefaultInstance.UpdateUserAsync(updatedUser);
    }
}