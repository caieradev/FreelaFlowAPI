using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IClientService : IScoped
{
    Task<IEnumerable<ClientItemDTO>> GetAll();
    Task<ClientDTO> GetById(Guid id);
    Task<ClientDTO> Create(CreateClientRequestDTO dto);
    Task<ClientDTO> Update(Guid id, UpdateClientRequestDTO dto);
    Task Delete(Guid id);
    Task AddLabel(Guid id, IdDTO dto);
    Task RemoveLabel(Guid id, Guid labelId);
    Task AddBiling(Guid id, CreateClientBillingRequestDTO dto);
    Task UpdateBiling(Guid id, Guid billingId, UpdateClientBillingRequestDTO dto);
    Task RemoveBilling(Guid id, Guid billingId);
}