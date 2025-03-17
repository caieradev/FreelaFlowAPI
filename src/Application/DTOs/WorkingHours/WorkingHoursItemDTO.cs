
using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct WorkHoursItemDTO
{
    public string startDate { get; set; }
    public TimeSpan duration { get; set; }
    public KeyValuePair<WorkHourCategoryEnum, string> category { get; set; }
    internal static WorkHoursItemDTO FromEntity(WorkHoursEntity workHoursEntity) =>
        new()
        {
            startDate = workHoursEntity.StartTime.ToString("dd/MM/yyyy"),
            duration = workHoursEntity.Duration!.Value,
            category = new KeyValuePair<WorkHourCategoryEnum, string>(workHoursEntity.Category, workHoursEntity.Category.ToString())
        };
}