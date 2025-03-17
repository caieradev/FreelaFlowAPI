using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProjectStatusDTO
{
    public ProjectStatusEnum projectStatus { get; set; }
}