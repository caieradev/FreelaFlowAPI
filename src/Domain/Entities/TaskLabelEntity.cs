using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class TaskLabelEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    
    public string Name { get; set; }
    public string Color { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<TaskTemplateTaskLabelEntity> TaskTemplateTaskLabel { get; set; } = [];
    public ICollection<TaskTaskLabelEntity> TaskTaskLabel { get; set; } = [];
}
