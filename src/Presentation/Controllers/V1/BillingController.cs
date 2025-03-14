using Microsoft.AspNetCore.Mvc;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Presentation.Controllers.V1;
[ApiController]
[Route("api/v{version:apiVersion}/Billing")]
[ApiVersion("1.0")]
public class BillingController(IBillingService service) : BaseController<IBillingService>(service)
{
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetAll() =>
        Ok(new ResponseDTO { data = await _mainService.GetAll() });
    
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetById(Guid id) =>
        Ok(new ResponseDTO { data = await _mainService.GetById(id) });
    
    [HttpPost("invoice")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> CreateInvoice(CreateInvoiceRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.CreateInvoice(dto) });
    
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateInvoice(Guid id, [FromBody] UpdateInvoiceRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.UpdateInvoice(id, dto) });
    
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> DeleteInvoice(Guid id)
    {
        await _mainService.DeleteInvoice(id);
        return Ok(new ResponseDTO { displayMessage = "Cobrança deletada com sucesso!" });
    }
    
    [HttpPost("invoice/{id}/send")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> SendInvoice(Guid id)
    {
        await _mainService.SendInvoice(id);
        return Ok(new ResponseDTO { displayMessage = "Cobrança enviada com sucesso" });
    }
    
    [HttpPost("{id}/payment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> RegisterPayment(Guid id)
    {
        await _mainService.RegisterPayment(id);
        return Ok(new ResponseDTO { displayMessage = "Pagamento registrado com sucesso" });
    }
    
    [HttpPost("{id}/payment/cancel")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> CancelPayment(Guid id)
    {
        await _mainService.CancelPayment(id);
        return Ok(new ResponseDTO { displayMessage = "Pagamento cancelado com sucesso" });
    }
    
    [HttpPost("{id}/receipt")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GenerateReceipt(Guid id, CreateReceiptRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.GenerateReceipt(id, dto) });
    
    [HttpPut("{id}/receipt")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateReceipt(Guid id, [FromBody] UpdateReceiptRequestDTO dto) =>
        Ok(new ResponseDTO { data = await _mainService.UpdateReceipt(id, dto) });
    
    [HttpPost("{id}/receipt/send")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> SendReceipt(Guid id)
    {
        await _mainService.SendReceipt(id);
        return Ok(new ResponseDTO { displayMessage = "Recibo enviado com sucesso" });
    }
    
    [HttpDelete("{id}/receipt")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> DeleteReceipt(Guid id)
    {
        await _mainService.DeleteReceipt(id);
        return Ok(new ResponseDTO { displayMessage = "Recibo deletado com sucesso" });
    }
}