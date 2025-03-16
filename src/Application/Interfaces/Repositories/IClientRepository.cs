using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Interfaces;
public interface IClientRepository : ITransient
{
    Task AddBilling(ClientBillingEntity clientBillingEntity);
    Task Delete(Guid id);
    Task DeleteBilling(Guid id);
    Task<IEnumerable<ClientEntity>> GetAll(Guid userId);
    Task<ClientEntity?> GetById(Guid id, bool withLabels, bool withBilling);
    Task<ClientEntity?> GetByIdComplete(Guid id);
    Task<ClientEntity> Insert(ClientEntity entity);
    Task<ClientEntity> Update(ClientEntity entity);
    Task UpdateBilling(ClientBillingEntity billingEntity);
    Task UpdateLabels(Guid id, IEnumerable<ClientClientLabelEntity> labelsAdd, IEnumerable<Guid> labelIdsToRemove);
}