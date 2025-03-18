using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Domain.Entities;
public class ProposalEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = new();

    public string? Description { get; set; }
    public ProposalStatusEnum Status { get; set; }
    public decimal? FixedPrice { get; set; }
    public decimal? HourlyRate { get; set; }
    public bool Accepted { get; set; } = false;
    public string? RejectionNote { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}