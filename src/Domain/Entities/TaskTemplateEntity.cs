using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class TaskTemplateEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }

    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<TaskTemplateTaskLabelEntity> TaskTemplateTaskLabel { get; set; } = [];
}
