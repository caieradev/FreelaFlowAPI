using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.DTOs;
public struct LabelsDTO
{
    public IEnumerable<Guid> labels { get; set; }
}