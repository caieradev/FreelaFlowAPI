using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface ITaskService : IScoped
{
    Task<IEnumerable<TaskItemDTO>> GetAll();
    Task<TaskDTO> GetById(Guid id);
    Task<TaskDTO> Create(CreateTaskRequestDTO id);
    Task<TaskDTO> Update(Guid id, UpdateTaskRequestDTO dto);
    Task Delete(Guid id);
}