using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/projects")]
[ApiVersion("1.0")]
public class ProjectController(IProjectService service) : BaseController<IProjectService>(service)
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
    public async Task<IActionResult> Create(ProjectRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Create(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProjectRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Update(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mainService.Delete(id);
        return Ok(new ResponseDTO { displayMessage = "Projeto deletado com sucesso!" });
    }
    
    [HttpPost("{id}/labels")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateLabels(Guid id, [FromBody] LabelsDTO dto)
    {
        await _mainService.UpdateLabels(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Labels atualizadas com sucesso!" });
    }
    
    [HttpPatch("{id}/status")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> SetStatus(Guid id, [FromBody] ProjectStatusDTO dto)
    {
        await _mainService.SetStatus(id, dto);
        return Ok(new ResponseDTO { displayMessage = "Status do projeto alterado com sucesso!" });
    }
}