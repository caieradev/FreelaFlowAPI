using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using FreelaFlowApi.Domain.Enums;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Exceptions;

namespace FreelaFlowApi.Application.Services;
public class AuthService(IHttpContextAccessor httpContextAccessor, IAuthClient authClient, IUserRepository userRepository) : BaseService(httpContextAccessor), IAuthService
{
    private readonly IAuthClient _authClient = authClient;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<UserDTO> RegisterAsync(string idToken, string externalUserId, string password) =>
        UserDTO.FromEntity(await this.PerformUserRegisterAsync(idToken, externalUserId, password));

    public async Task<UserEntity> PerformUserRegisterAsync(string idToken, string externalUserId, string password)
    {
        try
        {
            var tokenClaims = await _authClient.GetTokenClaims(idToken);
          
            var newUser = new UserEntity
            {
                ExternalId = externalUserId,
                Password = GetSha256Hash(password),
                CreatedAt = DateTime.UtcNow,
                Name = tokenClaims["name"].ToString() ??
                    throw new DebugMessageException("Nome não encontrado"),
                Email =  tokenClaims["email"].ToString() ??
                    throw new DebugMessageException("Email não encontrado"),
                Phone =  tokenClaims["phone"].ToString() ??
                    throw new DebugMessageException("Telefone não encontrado"),
            };

            newUser = await _userRepository.InsertOrUpdate(newUser);

            return (await _userRepository.GetByIdCompleteAsync(newUser.Id))!;
        }
        catch
        {
            await _authClient.DeleteUserAsync(externalUserId);
            throw;
        }
    }

    public async Task<Guid?> LoginAsync(string idToken)
    {
        var externalUserId = await _authClient
            .VerifyIdTokenAsync(idToken);

        if (externalUserId == null) 
            return null;

        var user = await _userRepository.GetUserByExternalIdAsync(externalUserId) ??
                throw new DebugMessageException("Usuário não encontrado");

        var claims = new Dictionary<string, object>
        {
            { ClaimEnum.Name.ToString(), user.Name },
            { ClaimEnum.Role.ToString(), user.Role.ToString() },
            { ClaimEnum.IUId.ToString(), user.Id },
            { ClaimEnum.EUId.ToString(), externalUserId },
        };

        await _authClient.SetCustomClaimsAsync(externalUserId, claims);

        return user.Id;
    }

    internal static string GetSha256Hash(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }
}