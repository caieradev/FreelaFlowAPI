using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IClientService : IScoped
{
    Task<IEnumerable<ClientItemDTO>> GetAll();
    Task<ClientDTO> GetById(Guid id);
    Task<ClientDTO> Create(CreateClientRequestDTO dto);
    Task<ClientDTO> Update(Guid id, UpdateClientRequestDTO dto);
    Task Delete(Guid id);
    Task UpdateLabels(Guid id, LabelsDTO labelsDto);
    Task AddBilling(Guid id, ClientBillingRequestDTO dto);
    Task UpdateBilling(Guid id, ClientBillingRequestDTO dto);
    Task RemoveBilling(Guid id);
}