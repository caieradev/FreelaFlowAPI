using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IUserService : IScoped
{
    Task<UserDTO> GetUser();
    Task<UserDTO> Update();
    Task<UserBillingDTO> CreateBilling(CreateUserBillingRequestDTO id);
    Task<UserBillingDTO> UpdateBilling(UpdateUserBillingRequestDTO dto);
    Task Delete();
    Task DeleteBilling();
}