using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class ClientClientLabelEntity : IEntity
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    
    public Guid ClientLabelId { get; set; }
    public ClientLabelEntity? ClientLabel { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
