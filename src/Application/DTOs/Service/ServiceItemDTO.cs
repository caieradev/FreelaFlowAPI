
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ServiceItemDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    internal static ServiceItemDTO FromEntity(ServiceEntity entity) =>
        new()
        {
            id = entity.Id,
            name = entity.Name
        };
}