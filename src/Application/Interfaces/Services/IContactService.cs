using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface IContactService : IScoped
{
    Task<IEnumerable<ContactItemDTO>> GetAll();
    Task<ContactDTO> GetById(Guid id);
    Task<ContactDTO> Create(CreateContactRequestDTO id);
    Task<ContactDTO> Update(Guid id, UpdateContactRequestDTO dto);
    Task Delete(Guid id);
}