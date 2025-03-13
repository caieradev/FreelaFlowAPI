using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.Attributes;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers;
[ApiController]
[Route("api/v{version:apiVersion}/Auth")]
[ApiVersion("1.0")]
public class AuthController(IAuthService service) : BaseController<IAuthService>(service)
{
    [SkipAuthentication]
    [HttpPost("register")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO dto)
    {
        var user = await _mainService.RegisterAsync(dto.idToken, dto.externalUserId, dto.password);

        return Ok(new ResponseDTO 
        { 
            data = user,
            displayMessage = "Usuário registrado com sucesso!" 
        });
    }

    [SkipAuthentication]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] IdTokenDTO request)
    {
        var userId = await _mainService.LoginAsync(request.idToken);

        if (userId == null)
            return Unauthorized(new ResponseDTO { displayMessage = "Email ou senha inválido!" });

        return Ok(new ResponseDTO
        {
            displayMessage = "Usuário logado com sucesso!"
        });
    }
}