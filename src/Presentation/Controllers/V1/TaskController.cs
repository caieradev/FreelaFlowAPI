using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/tasks")]
[ApiVersion("1.0")]
public class TaskController(ITaskService Task) : BaseController<ITaskService>(Task)
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
    public async Task<IActionResult> Create(CreateTaskRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Create(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.Update(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mainService.Delete(id);
        return Ok(new ResponseDTO { displayMessage = "Tarefa deletada com sucesso!" });
    }
}