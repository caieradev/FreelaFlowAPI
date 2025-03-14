using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IWorkHoursService : IScoped
{
    Task<IEnumerable<WorkHoursItemDTO>> GetAll();
    Task<WorkHoursDTO> GetById(Guid id);
    Task<WorkHoursDTO> Create(CreateWorkHoursRequestDTO id);
    Task<WorkHoursDTO> Update(Guid id, UpdateWorkHoursRequestDTO dto);
    Task Delete(Guid id);
}