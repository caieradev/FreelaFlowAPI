namespace FreelaFlowApi.Application.DTOs;
public struct RegisterRequestDTO
{
    public string idToken { get; set; }
    public string externalUserId { get; set; }
    public string password { get; set; }
}