using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class ClientEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ClientCategoryEnum Category { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ClientBillingEntity? ClientBilling { get; set; }
    public ICollection<ClientClientLabelEntity> ClientClientLabels { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
    public ICollection<InvoiceEntity> Invoices { get; set; } = [];
}
