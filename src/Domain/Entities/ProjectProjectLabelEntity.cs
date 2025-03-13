using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class ProjectProjectLabelEntity : IEntity
{
    public Guid Id { get; set; }
    
    public Guid ProjectId { get; set; }
    public ProjectEntity? Project { get; set; }
    
    public Guid ProjectLabelId { get; set; }
    public ProjectLabelEntity? ProjectLabel { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}