using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ClientBillingDTO
{
    public Guid id { get; set; }
    public string? documentNumber { get; set; }
    public string? address { get; set; }
    public string? neighborhood { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? country { get; set; }
    public string? zipCode { get; set; }
    public string? addressComplement { get; set; }

    internal static ClientBillingDTO FromEntity(ClientBillingEntity billing) =>
        new()
        {
            id = billing.Id,
            documentNumber = billing.DocumentNumber,
            address = billing.Address,
            neighborhood = billing.Neighborhood,
            city = billing.City,
            state = billing.State,
            country = billing.Country,
            zipCode = billing.ZipCode,
            addressComplement = billing.AddressComplement
        };
}