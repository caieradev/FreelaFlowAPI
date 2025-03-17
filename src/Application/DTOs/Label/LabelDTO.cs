using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct LabelDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string color { get; set; }

    internal static LabelDTO FromEntity(ClientLabelEntity clientLabel) =>
        new()
        {
            id = clientLabel.Id,
            name = clientLabel.Name,
            color = clientLabel.Color
        };

    internal static LabelDTO FromEntity(ProjectLabelEntity projectLabel) =>
        new()
        {
            id = projectLabel.Id,
            name = projectLabel.Name,
            color = projectLabel.Color
        };
}