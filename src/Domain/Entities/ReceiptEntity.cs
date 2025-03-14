using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class ReceiptEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    
    public Guid InvoiceId { get; set; }
    public InvoiceEntity Invoice { get; set; } = new();
    public decimal Amount { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}