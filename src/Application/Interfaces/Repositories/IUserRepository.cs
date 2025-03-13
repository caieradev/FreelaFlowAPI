using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IUserRepository : ITransient
{
    Task<UserEntity?> GetByIdCompleteAsync(Guid id);
    Task<UserEntity> InsertOrUpdate(UserEntity entity);
    Task<UserEntity?> GetUserByExternalIdAsync(string externalUserId);
}