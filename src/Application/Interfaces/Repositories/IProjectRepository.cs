using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProjectRepository : ITransient
{
    Task<IEnumerable<ProjectEntity>> GetAll(Guid userId);
    Task<ProjectEntity?> GetById(Guid projectId, bool withLabels, bool withServices);
    Task<ProjectEntity?> GetByIdComplete(Guid projectId);
    Task<ProjectEntity> Create(ProjectEntity entity);
    Task<ProjectEntity> Update(ProjectEntity projectEntity);
    Task Delete(ProjectEntity project);
    Task DeleteByClientId(Guid id);
    Task UpdateLabels(Guid id, IEnumerable<ProjectProjectLabelEntity> labelsAdd, IEnumerable<Guid> labelIdsToRemove);
}