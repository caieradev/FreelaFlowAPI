using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/user")]
[ApiVersion("1.0")]
public class UserController(IUserService service) : BaseController<IUserService>(service)
{    
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetUser() =>
        Ok(new ResponseDTO { data = await _mainService.GetUser() });
    
    [HttpPut]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update() =>
        Ok(new ResponseDTO { data = await _mainService.Update() });
    
    [HttpDelete]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete()
    {
        await _mainService.Delete();
        return Ok(new ResponseDTO { displayMessage = "Usuário deletado com sucesso!" });
    }
    
    [HttpPost("billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> CreateBilling(CreateUserBillingRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.CreateBilling(dto) });
    
    [HttpPost("billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateBilling(UpdateUserBillingRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.UpdateBilling(dto) });
    
    [HttpDelete("billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> DeleteBilling()
    {
        await _mainService.DeleteBilling();
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança deletadas com sucesso!" });
    }
}