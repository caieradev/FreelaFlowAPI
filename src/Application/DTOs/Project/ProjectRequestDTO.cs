using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProjectRequestDTO
{
    public Guid clientId { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public ProjectStatusEnum status { get; set; }
    public decimal? fixedPrice { get; set; }
    public decimal? hourlyRate { get; set; }
    public bool isRecurring { get; set; }

    internal static ProjectEntity ToEntity(ProjectRequestDTO dto, Guid userId) =>
        new()
        {
            UserId = userId,
            ClientId = dto.clientId,
            Name = dto.name,
            Description = dto.description,
            Status = dto.status,
            FixedPrice = dto.fixedPrice,
            HourlyRate = dto.hourlyRate,
            IsRecurring = dto.isRecurring
        };

    internal static ProjectEntity UpdateEntity(ProjectRequestDTO dto, ProjectEntity projectEntity)
    {
        projectEntity.ClientId = dto.clientId;
        projectEntity.Name = dto.name;
        projectEntity.Description = dto.description;
        projectEntity.Status = dto.status;
        projectEntity.FixedPrice = dto.fixedPrice;
        projectEntity.HourlyRate = dto.hourlyRate;
        projectEntity.IsRecurring = dto.isRecurring;

        return projectEntity;
    }
}