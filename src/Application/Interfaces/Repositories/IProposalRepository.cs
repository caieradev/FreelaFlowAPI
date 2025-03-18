using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IProposalRepository : ITransient
{
    Task<IEnumerable<ProposalEntity>> GetAllFromProject(Guid clientId);
    Task<ProposalEntity?> GetById(Guid id);
    Task<ProposalEntity> Create(ProposalEntity entity);
    Task<ProposalEntity> Update(ProposalEntity entity);
    Task Delete(ProposalEntity entity);
    Task DeleteAllFromProject(Guid id);
    Task DeleteAllFromClient(Guid id);
}