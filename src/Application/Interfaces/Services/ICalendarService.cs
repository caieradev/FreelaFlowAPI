using FreelaFlowApi.Application.DTOs;

namespace FreelaFlowApi.Application.Interfaces;
public interface ICalendarService : IScoped
{
    Task<IEnumerable<CalendarItemDTO>> GetAll();
    Task<CalendarDTO> GetById(Guid id);
    Task<CalendarDTO> Create(CreateCalendarRequestDTO id);
    Task<CalendarDTO> Update(Guid id, UpdateCalendarRequestDTO dto);
    Task Delete(Guid id);
}