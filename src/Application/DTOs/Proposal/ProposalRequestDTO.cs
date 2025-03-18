using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProposalRequestDTO
{
    public Guid ProjectId { get; set; }
    public decimal? FixedPrice { get; set; }
    public decimal? HourlyRate { get; set; }
    public string? Description { get; set; }

    public static ProposalEntity ToNewEntity(ProposalRequestDTO dto) =>
        new()
        {
            ProjectId = dto.ProjectId,
            FixedPrice = dto.FixedPrice,
            HourlyRate = dto.HourlyRate,
            Status = ProposalStatusEnum.Draft,
            Description = dto.Description
        };

    internal static ProposalEntity UpdateEntity(ProposalRequestDTO dto, ProposalEntity proposal)
    {
        proposal.FixedPrice = dto.FixedPrice;
        proposal.HourlyRate = dto.HourlyRate;
        proposal.Description = dto.Description;
        return proposal;
    }
}