using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IAuthService : IScoped
{   
    Task<UserDTO> RegisterAsync(string idToken, string externalUserId, string password);
    Task<UserEntity> PerformUserRegisterAsync(string idToken, string externalUserId, string password);
    Task<Guid?> LoginAsync(string idToken);
}