using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/Label")]
[ApiVersion("1.0")]
public class LabelController(ILabelService service) : BaseController<ILabelService>(service)
{
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetAll(LabelTypeEnum labelType) =>
        Ok(new ResponseDTO { data = await _mainService.GetAll(labelType) });
    
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetById(Guid id) =>
        Ok(new ResponseDTO { data = await _mainService.GetById(id) });
    
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateLabelRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Create(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLabelRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Update(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mainService.Delete(id);
        return Ok(new ResponseDTO { displayMessage = "Label deletada com sucesso!" });
    }
}