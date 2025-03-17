using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ProjectItemDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public bool isRecurring { get; set; }
    public IEnumerable<LabelDTO> labels { get; set; }

    internal static ProjectItemDTO FromEntity(ProjectEntity entity) =>
        new()
        {
            id = entity.Id,
            name = entity.Name,
            isRecurring = entity.IsRecurring,
            labels = entity.ProjectProjectLabels
                .Select(x => LabelDTO.FromEntity(x.ProjectLabel))
        };
}