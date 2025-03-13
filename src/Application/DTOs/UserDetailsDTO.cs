using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public class UserDetailsDTO
{
    public int? id { get; set; }
    public string externalUserId { get; set; }
    public string? idToken { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public bool active { get; set; }
    public UserRoleEnum? role { get; set; }

    internal static UserDetailsDTO FromEntity(UserEntity entity) =>
        new()
        {
            // id = entity.Id,
            // externalUserId = entity.ExternalId,
            // name = entity.Name,
            // email = entity.Email,
            // active = entity.Active,
            // role = entity.Role
        };
}