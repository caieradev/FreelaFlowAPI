using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/proposals")]
[ApiVersion("1.0")]
public class ProposalController(IProposalService service) : BaseController<IProposalService>(service)
{
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetAll([FromQuery] Guid clientId) =>
        Ok(new ResponseDTO { data = await _mainService.GetAllFromProject(clientId) });
    
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetById(Guid id) =>
        Ok(new ResponseDTO { data = await _mainService.GetById(id) });
    
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(ProposalRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Create(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProposalRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Update(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mainService.Delete(id);
        return Ok(new ResponseDTO { displayMessage = "Proposta deletada com sucesso!" });
    }
    
    [HttpPost("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> SetStatus(Guid id, ProposalStatusDTO dto)
    {
        await _mainService.SetStatus(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Proposta deletada com sucesso!" });
    }
    
    // [HttpPost("{id}/send")]
    // [MapToApiVersion("1.0")]
    // public async Task<IActionResult> SendToClient(Guid id)
    // {
    //     await _mainService.SendToClient(id);
    //     return Ok(new ResponseDTO { displayMessage = "Proposta enviada com sucesso!" });
    // }
    
    [HttpPost("{id}/response")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ClientResponse(Guid id, ProposalResponseDTO dto)
    {
        await _mainService.ClientResponse(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Resposta enviada com sucesso!" });
    }
}