using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.Attributes;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/Auth")]
[ApiVersion("1.0")]
public class AuthController(IAuthService service) : BaseController<IAuthService>(service)
{
    [SkipAuthentication]
    [HttpPost("register")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO dto) =>
        Ok(new ResponseDTO 
        { 
            data = await _mainService.RegisterAsync(dto.idToken, dto.externalUserId, dto.password),
            displayMessage = "Usuário registrado com sucesso!" 
        });

    [SkipAuthentication]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request) =>
        await _mainService.LoginAsync(request.idToken) == null ? 
            Unauthorized(new ResponseDTO { displayMessage = "Email ou senha inválido!" }) :
            Ok();
}