using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class TaskEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    
    public Guid? ProjectId { get; set; }
    public ProjectEntity? Project { get; set; }
    
    public Guid? ClientId { get; set; }
    public ClientEntity? Client { get; set; }

    public Guid? ParentTaskId { get; set; }
    public TaskEntity? ParentTask { get; set; }
    
    public string Title { get; set; }
    public string? Description { get; set; }
    public TaskStatusEnum Status { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<TaskTaskLabelEntity> TaskTaskLabels { get; set; } = [];
    public ICollection<WorkHoursEntity> WorkHours { get; set; } = [];
    public ICollection<TaskEntity> SubTasks { get; set; } = [];
}