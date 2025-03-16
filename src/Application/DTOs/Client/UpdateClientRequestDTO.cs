using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct UpdateClientRequestDTO
{
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public ClientCategoryEnum category { get; set; }

    internal static ClientEntity UpdateEntity(UpdateClientRequestDTO dto, ClientEntity client)
    {
        client.Name = dto.name;
        client.Email = dto.email;
        client.Phone = dto.phone;
        client.Category = dto.category;

        return client;
    }
}