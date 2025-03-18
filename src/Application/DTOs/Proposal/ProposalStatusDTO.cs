using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProposalStatusDTO
{
    public ProposalStatusEnum Status { get; set; }
}