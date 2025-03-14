using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProposalService : IScoped
{
    Task<IEnumerable<ProposalItemDTO>> GetAll();
    Task<ProposalDTO> GetById(Guid id);
    Task<ProposalDTO> Create(CreateProposalRequestDTO id);
    Task<ProposalDTO> Update(Guid id, UpdateProposalRequestDTO dto);
    Task Delete(Guid id);
    Task SendToClient(Guid id);
    Task ClientResponse(Guid id, ProposalResponseDTO labelId);
}