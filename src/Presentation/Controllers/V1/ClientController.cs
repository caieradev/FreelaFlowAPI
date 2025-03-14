using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.Attributes;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/clients")]
[ApiVersion("1.0")]
public class ClientController(IClientService service) : BaseController<IClientService>(service)
{
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetAll() =>
        Ok(new ResponseDTO { data = await _mainService.GetAll() });
    
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetById(Guid id) =>
        Ok(new ResponseDTO { data = await _mainService.GetById(id) });
    
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateClientRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Create(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClientRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Update(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mainService.Delete(id);
        return Ok(new ResponseDTO { displayMessage = "Cliente deletado com sucesso!" });
    }
    
    [HttpPost("{id}/labels")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> AddLabel(Guid id, [FromBody] IdDTO dto)
    {
        await _mainService.AddLabel(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Label adicionada com sucesso!" });
    }
    
    [HttpDelete("{id}/labels/{labelId}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> RemoveLabel(Guid id, Guid labelId)
    {
        await _mainService.RemoveLabel(id, labelId);
        return Ok(new ResponseDTO { displayMessage = "Label removida com sucesso!" });
    }
    
    [HttpPost("{id}/billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> AddBiling(Guid id, [FromBody] CreateClientBillingRequestDTO dto)
    {
        await _mainService.AddBiling(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança adicionadas com sucesso!" });
    }
    [HttpPut("{id}/billing/{billingId}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateBiling(Guid id, Guid billingId, [FromBody] UpdateClientBillingRequestDTO dto)
    {
        await _mainService.UpdateBiling(id, billingId, dto);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança atualizadas com sucesso!" });
    }
    
    [HttpDelete("{id}/billing/{billingId}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> RemoveBilling(Guid id, Guid billingId)
    {
        await _mainService.RemoveBilling(id, billingId);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança removidas com sucesso!" });
    }
}