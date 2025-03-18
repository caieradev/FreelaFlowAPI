using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProposalService : IScoped
{
    Task<IEnumerable<ProposalItemDTO>> GetAllFromProject(Guid clientId);
    Task<ProposalDTO> GetById(Guid id);
    Task<ProposalDTO> Create(ProposalRequestDTO id);
    Task<ProposalDTO> Update(Guid id, ProposalRequestDTO dto);
    Task Delete(Guid id);
    // Task SendToClient(Guid id);
    Task ClientResponse(Guid id, ProposalResponseDTO responseDto);
    Task SetStatus(Guid id, ProposalStatusDTO dto);
}