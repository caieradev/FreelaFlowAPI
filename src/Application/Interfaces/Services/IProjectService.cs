using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProjectService : IScoped
{
    Task<IEnumerable<ProjectItemDTO>> GetAll();
    Task<ProjectDTO> GetById(Guid id);
    Task<ProjectDTO> Create(ProjectRequestDTO id);
    Task<ProjectDTO> Update(Guid id, ProjectRequestDTO dto);
    Task Delete(Guid id);
    Task UpdateLabels(Guid id, LabelsDTO dto);
    Task SetStatus(Guid id, ProjectStatusDTO dto);
    Task<ProjectEntity> GetProjectAndValidateAccess(Guid projectId, bool complete = false, bool withLabels = false, bool withServices = false);
}