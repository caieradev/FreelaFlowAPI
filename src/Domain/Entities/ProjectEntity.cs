using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class ProjectEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
    
    public Guid ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public ProjectStatusEnum Status { get; set; }
    public decimal? FixedPrice { get; set; }
    public decimal? HourlyRate { get; set; }
    public bool IsRecurring { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<ProjectProjectLabelEntity> ProjectProjectLabels { get; set; } = [];
    public ICollection<TaskEntity> Tasks { get; set; } = [];
    public ICollection<ProjectServiceEntity> ProjectServices { get; set; } = [];
    public ICollection<WorkHoursEntity> WorkHours { get; set; } = [];
}