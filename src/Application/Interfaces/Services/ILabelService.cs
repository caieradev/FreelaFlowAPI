using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.Interfaces;
public interface ILabelService : IScoped
{
    Task<LabelDTO> GetById(Guid id);
    Task<LabelDTO> Create(CreateLabelRequestDTO id);
    Task<LabelDTO> Update(Guid id, UpdateLabelRequestDTO dto);
    Task Delete(Guid id);
    Task<IEnumerable<LabelItemDTO>> GetAll(LabelTypeEnum labelType);
}