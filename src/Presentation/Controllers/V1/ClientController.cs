using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> UpdateLabels(Guid id, [FromBody] LabelsDTO dto)
    {
        await _mainService.UpdateLabels(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Labels atualizadas com sucesso!" });
    }
    
    [HttpPost("{id}/billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> AddBilling(Guid id, [FromBody] ClientBillingRequestDTO dto)
    {
        await _mainService.AddBilling(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança adicionadas com sucesso!" });
    }

    [HttpPut("{id}/billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateBilling(Guid id, [FromBody] ClientBillingRequestDTO dto)
    {
        await _mainService.UpdateBilling(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança atualizadas com sucesso!" });
    }
    
    [HttpDelete("{id}/billing")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> RemoveBilling(Guid id)
    {
        await _mainService.RemoveBilling(id);
        return Ok(new ResponseDTO { displayMessage = "Informações de cobrança removidas com sucesso!" });
    }
}