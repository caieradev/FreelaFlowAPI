using System.Threading.Tasks;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Exceptions;
using FreelaFlowApi.Application.Extensions;
using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Services;
public class ProposalService(
    IHttpContextAccessor httpContextAccessor, 
    IProposalRepository proposalRepository, 
    IProjectService projectService
) : BaseService(httpContextAccessor), IProposalService
{
    private readonly IProposalRepository _proposalRepository = proposalRepository;
    private readonly IProjectService _projectService = projectService;

    public async Task<ProposalDTO> Create(ProposalRequestDTO dto)
    {
        ValidateRequest(dto);
        await _projectService.GetProjectAndValidateAccess(dto.ProjectId);

        var proposal = await _proposalRepository.Create(ProposalRequestDTO.ToNewEntity(dto));
        return ProposalDTO.FromEntity(proposal);
    }

    public async Task<ProposalDTO> Update(Guid id, ProposalRequestDTO dto)
    {
        ValidateId(id, "Proposta");
        ValidateRequest(dto);
        
        var proposal = await GetProposalAndValidateAccess(id);
        proposal = ProposalRequestDTO.UpdateEntity(dto, proposal);

        var updatedProposal = await _proposalRepository.Update(proposal);
        return ProposalDTO.FromEntity(updatedProposal);
    }

    public async Task Delete(Guid id)
    {
        var proposal = await GetProposalAndValidateAccess(id);
        await _proposalRepository.Delete(proposal);
    }

    public async Task<ProposalDTO> GetById(Guid id)
    {
        ValidateId(id, "Proposta");
        
        var proposal = await _proposalRepository.GetById(id) ?? 
            throw new DebugMessageException("Proposta não encontrada!");
        
        await _projectService.GetProjectAndValidateAccess(proposal.ProjectId);
        return ProposalDTO.FromEntity(proposal);
    }

    public async Task<IEnumerable<ProposalItemDTO>> GetAllFromProject(Guid projectId)
    {
        ValidateId(projectId, "Projeto");
        await _projectService.GetProjectAndValidateAccess(projectId);
        
        var proposals = await _proposalRepository.GetAllFromProject(projectId);
        return proposals.Select(ProposalItemDTO.FromEntity);
    }

    public async Task ClientResponse(Guid id, ProposalResponseDTO response)
    {
        var proposal = await GetProposalAndValidateAccess(id);
        
        proposal.Accepted = response.accepted;
        proposal.RejectionNote = response.rejectionNote;

        await _proposalRepository.Update(proposal);
    }

    public async Task SetStatus(Guid id, ProposalStatusDTO statusDto)
    {
        var proposal = await GetProposalAndValidateAccess(id);
        
        proposal.Status = statusDto.Status;
        await _proposalRepository.Update(proposal);
    }

    private async Task<ProposalEntity> GetProposalAndValidateAccess(Guid id)
    {
        ValidateId(id, "Proposta");
        
        var proposal = await _proposalRepository.GetById(id) ?? 
            throw new DebugMessageException("Proposta não encontrada!");
            
        await _projectService.GetProjectAndValidateAccess(proposal.ProjectId);
        return proposal;
    }

    private static void ValidateRequest(ProposalRequestDTO dto)
    {
        ValidateId(dto.ProjectId, "Projeto");
        
        if (dto.FixedPrice == null && dto.HourlyRate == null)
            throw new DebugMessageException("Pelo menos um dos valores deve ser informado!");
    }

    private static void ValidateId(Guid id, string entityName)
    {
        if (id == Guid.Empty)
            throw new DebugMessageException($"ID do {entityName} é obrigatório!");
    }
}
