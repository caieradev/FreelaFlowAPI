namespace FreelaFlowApi.Application.DTOs;
public struct ResponseDTO
{
    public string? displayMessage { get; set; }
    public string? debugMessage { get; set; }
    public object data { get; set; }
}