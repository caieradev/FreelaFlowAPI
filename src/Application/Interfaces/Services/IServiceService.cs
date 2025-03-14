using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IServiceService : IScoped
{
    Task<IEnumerable<ServiceItemDTO>> GetAll();
    Task<ServiceDTO> GetById(Guid id);
    Task<ServiceDTO> Create(CreateServiceRequestDTO id);
    Task<ServiceDTO> Update(Guid id, UpdateServiceRequestDTO dto);
    Task Delete(Guid id);
}