using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ContactItemDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string? ownerName { get; set; }

    internal static ContactItemDTO FromEntity(ContactEntity contact) =>
        new()
        {
            id = contact.Id,
            name = contact.Name,
            ownerName = contact.Client?.Name
        };
}