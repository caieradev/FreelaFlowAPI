using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IBillingService : IScoped
{
    Task<IEnumerable<BillingItemDTO>> GetAll();
    Task<BillingDTO> GetById(Guid id);
    Task<BillingDTO> CreateInvoice(CreateInvoiceRequestDTO id);
    Task<BillingDTO> UpdateInvoice(Guid id, UpdateInvoiceRequestDTO dto);
    Task DeleteInvoice(Guid id);
    Task SendInvoice(Guid id);
    Task RegisterPayment(Guid id);
    Task<object> UpdateReceipt(Guid id, UpdateReceiptRequestDTO dto);
    Task<object> GenerateReceipt(Guid id, CreateReceiptRequestDTO dto);
    Task SendReceipt(Guid id);
    Task DeleteReceipt(Guid id);
    Task CancelPayment(Guid id);
}