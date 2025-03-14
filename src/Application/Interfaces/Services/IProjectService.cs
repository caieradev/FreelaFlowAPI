using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProjectService : IScoped
{
    Task<IEnumerable<ProjectItemDTO>> GetAll();
    Task<ProjectDTO> GetById(Guid id);
    Task<ProjectDTO> Create(CreateProjectRequestDTO id);
    Task<ProjectDTO> Update(Guid id, UpdateProjectRequestDTO dto);
    Task Delete(Guid id);
    Task AddLabel(Guid id, IdDTO dto);
    Task RemoveLabel(Guid id, Guid labelId);
    Task AddBiling(Guid id, ProjectStatusDTO dto);
}