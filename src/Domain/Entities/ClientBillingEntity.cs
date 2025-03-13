using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Domain.Entities;
public class ClientBillingEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public ClientEntity? Client { get; set; }
    
    public string DocumentNumber { get; set; } // CPF or CNPJ
    public string Address { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string AddressComplement { get; set; }
    
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}