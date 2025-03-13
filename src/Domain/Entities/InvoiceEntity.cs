using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class InvoiceEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    
    public Guid ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public bool Paid { get; set; } = false;
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ReceiptEntity? Receipt { get; set; }
}
