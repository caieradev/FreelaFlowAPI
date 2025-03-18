using System.Threading.Tasks;
using System.Transactions;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Exceptions;
using FreelaFlowApi.Application.Extensions;
using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Services;
public class ProjectService(IHttpContextAccessor httpContextAccessor, IProjectRepository projectRepository, IClientService clientService, IProposalRepository proposalRepository) : BaseService(httpContextAccessor), IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IClientService _clientService = clientService;
    private readonly IProposalRepository _proposalRepository = proposalRepository;

    public async Task SetStatus(Guid id, ProjectStatusDTO dto)
    {
        var project = await GetProjectAndValidateAccess(id);
        project.Status = dto.projectStatus;
        
        await _projectRepository.Update(project);
    }

    public async Task<ProjectDTO> Create(ProjectRequestDTO dto)
    {
        ValidateProjectRequestDTO(dto);
        await _clientService.GetClientByIdAndValidateAccess(dto.clientId);

        var project = ProjectRequestDTO.ToEntity(dto, GetUserId());
        return ProjectDTO.FromEntity(await _projectRepository.Create(project));
    }

    public async Task Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new DebugMessageException("ProjectId é obrigatório!");
        var project = await GetProjectAndValidateAccess(id);

        using TransactionScope ts = new(TransactionScopeAsyncFlowOption.Enabled);
        await _proposalRepository.DeleteAllFromProject(id);
        await _projectRepository.Delete(project);
        ts.Complete();
        ts.Dispose();
    }

    public async Task<IEnumerable<ProjectItemDTO>> GetAll()
    {
        var projects = await _projectRepository.GetAll(GetUserId());
        return projects.Select(ProjectItemDTO.FromEntity);
    }

    public async Task<ProjectDTO> GetById(Guid projectId) =>
        ProjectDTO.FromEntity(await GetProjectAndValidateAccess(projectId, complete: true));

    public async Task<ProjectDTO> Update(Guid id, ProjectRequestDTO dto)
    {
        ValidateProjectRequestDTO(dto);
        var projectEntity = await GetProjectAndValidateAccess(id);

        projectEntity = ProjectRequestDTO.UpdateEntity(dto, projectEntity);

        return ProjectDTO.FromEntity(await _projectRepository.Update(projectEntity));
    }

    public async Task UpdateLabels(Guid id, LabelsDTO labelsDto)
    {
        var projectEntity = await GetProjectAndValidateAccess(id, withLabels: true);
        
        var labelsAdd = labelsDto.labels
            .Except(projectEntity.ProjectProjectLabels
                .Select(x => x.ProjectLabelId))
            .Select(x => new ProjectProjectLabelEntity
            {
                ProjectId = id,
                ProjectLabelId = x
            });

        var labelIdsToRemove = projectEntity.ProjectProjectLabels
            .Select(x => x.ProjectLabelId)
            .Except(labelsDto.labels);

        await _projectRepository.UpdateLabels(id, labelsAdd, labelIdsToRemove);  
    }

    public async Task<ProjectEntity> GetProjectAndValidateAccess(Guid projectId, bool complete = false, bool withLabels = false, bool withServices = false)
    {
        var entity = (complete ? 
            await _projectRepository.GetByIdComplete(projectId) : 
            await _projectRepository.GetById(projectId, withLabels, withServices)) 
            ?? throw new DebugMessageException("Projeto não encontrado");

        if (entity.UserId != GetUserId())
            throw new MessageException("Você não tem acesso a esse projeto!");

        return entity;
    }

    private static void ValidateProjectRequestDTO(ProjectRequestDTO dto)
    {
        if (dto.clientId == Guid.Empty)
            throw new MessageException("Cliente não informado");
        if (string.IsNullOrWhiteSpace(dto.name))
            throw new MessageException("Nome do projeto não informado");
    }
}