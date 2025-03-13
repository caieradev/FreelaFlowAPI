using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class ProjectServiceEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public ProjectEntity? Project { get; set; }
    
    public Guid ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}