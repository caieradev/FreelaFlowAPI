using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class TaskTaskLabelEntity : IEntity
{
    public Guid Id { get; set; }
    
    public Guid TaskLabelId { get; set; }
    public TaskLabelEntity TaskLabel { get; set; } = new();

    public Guid TaskId { get; set; }
    public TaskEntity Task { get; set; } = new();
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
