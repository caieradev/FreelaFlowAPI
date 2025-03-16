using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct CreateClientRequestDTO
{
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public ClientCategoryEnum category { get; set; }

    internal static ClientEntity ToEntity(CreateClientRequestDTO dto, Guid userId) =>
        new()
        {
            UserId = userId,
            Name = dto.name,
            Email = dto.email,
            Phone = dto.phone,
            Category = dto.category
        };
}