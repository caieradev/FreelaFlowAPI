using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ClientItemDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public IEnumerable<LabelDTO> labels { get; set; }

    internal static ClientItemDTO FromEntity(ClientEntity entity) =>
        new()
        {
            id = entity.Id,
            name = entity.Name,
            category = entity.Category.ToString(),
            labels = entity.ClientClientLabels
                .Select(x => LabelDTO.FromEntity(x.ClientLabel))
        };
}