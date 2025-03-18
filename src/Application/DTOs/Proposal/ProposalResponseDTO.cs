namespace FreelaFlowApi.Application.DTOs;
public struct ProposalResponseDTO
{
    public bool accepted { get; set; }
    public string? rejectionNote { get; set; }
}