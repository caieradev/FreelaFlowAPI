using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class ContactEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    
    public Guid? ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
