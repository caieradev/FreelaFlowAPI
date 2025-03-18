using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ProposalDTO
{
    public Guid id { get; set; }
    public string status { get; set; }
    public decimal? fixedPrice { get; set; }
    public decimal? hourlyRate { get; set; }
    public bool accepted { get; set; }
    public string? rejectionNote { get; set; }
    
    internal static ProposalDTO FromEntity(ProposalEntity entity) =>
        new()
        {
            id = entity.Id,
            status = entity.Status.ToString(),
            fixedPrice = entity.FixedPrice,
            hourlyRate = entity.HourlyRate,
            accepted = entity.Accepted,
            rejectionNote = entity.RejectionNote
        };
}