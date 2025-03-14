using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class UserEntity : IEntity
{
    public Guid Id { get; set; }
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public UserRoleEnum Role { get; set; } = UserRoleEnum.Freelancer;
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public UserBillingEntity? UserBilling { get; set; }
    public ICollection<ClientEntity> Clients { get; set; } = [];
    public ICollection<ProjectLabelEntity> ProjectLabels { get; set; } = [];
    public ICollection<ClientLabelEntity> ClientLabels { get; set; } = [];
    public ICollection<TaskLabelEntity> TaskLabels { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
    public ICollection<ServiceEntity> Services { get; set; } = [];
    public ICollection<TaskEntity> Tasks { get; set; } = [];
    public ICollection<InvoiceEntity> Invoices { get; set; } = [];
    public ICollection<ReceiptEntity> Receipts { get; set; } = [];
    public ICollection<WorkHoursEntity> WorkHours { get; set; } = [];
}
