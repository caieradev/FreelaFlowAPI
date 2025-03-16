using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ClientDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string? phone { get; set; }
    public string category { get; set; }
    public ClientBillingDTO? billing { get; set; }
    public IEnumerable<ContactItemDTO> contacts { get; set; }
    public IEnumerable<LabelDTO> labels { get; set; }

    internal static ClientDTO FromEntity(ClientEntity client) =>
        new()
        {
            id = client.Id,
            name = client.Name,
            email = client.Email,
            phone = client.Phone,
            category = client.Category.ToString(),
            labels = client.ClientClientLabels
                .Select(x => LabelDTO.FromEntity(x.ClientLabel)),
            billing = client.ClientBilling != null
                ? ClientBillingDTO.FromEntity(client.ClientBilling)
                : null,
            contacts = client.Contacts
                .Select(ContactItemDTO.FromEntity)
        };
}