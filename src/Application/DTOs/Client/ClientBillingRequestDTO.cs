using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct ClientBillingRequestDTO
{
    public string? documentNumber { get; set; }
    public string? address { get; set; }
    public string? neighborhood { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? country { get; set; }
    public string? zipCode { get; set; }
    public string? addressComplement { get; set; }

    internal static ClientBillingEntity ToEntity(ClientBillingRequestDTO dto, Guid id) =>
        new()
        {
            ClientId = id,
            DocumentNumber = dto.documentNumber,
            Address = dto.address,
            Neighborhood = dto.neighborhood,
            City = dto.city,
            State = dto.state,
            Country = dto.country,
            ZipCode = dto.zipCode,
            AddressComplement = dto.addressComplement
        };

    internal static ClientBillingEntity UpdateEntity(ClientBillingRequestDTO dto, ClientBillingEntity billingEntity)
    {
        billingEntity.DocumentNumber = dto.documentNumber;
        billingEntity.Address = dto.address;
        billingEntity.Neighborhood = dto.neighborhood;
        billingEntity.City = dto.city;
        billingEntity.State = dto.state;
        billingEntity.Country = dto.country;
        billingEntity.ZipCode = dto.zipCode;
        billingEntity.AddressComplement = dto.addressComplement;

        return billingEntity;
    }
}