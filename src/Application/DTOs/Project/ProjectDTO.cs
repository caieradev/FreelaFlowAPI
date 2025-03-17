
using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProjectDTO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public KeyValuePair<ProjectStatusEnum, string> status { get; set; }
    public decimal? fixedPrice { get; set; }
    public decimal? hourlyRate { get; set; }
    public bool isRecurring { get; set; }
    public IEnumerable<LabelDTO> labels { get; set; }
    public IEnumerable<ServiceItemDTO> services { get; set; }
    public IEnumerable<WorkHoursItemDTO> workHours { get; set; }

    internal static ProjectDTO FromEntity(ProjectEntity projectEntity) =>
        new()
        {
            id = projectEntity.Id,
            name = projectEntity.Name,
            description = projectEntity.Description,
            status = new KeyValuePair<ProjectStatusEnum, string>(projectEntity.Status, projectEntity.Status.ToString()),
            fixedPrice = projectEntity.FixedPrice,
            hourlyRate = projectEntity.HourlyRate,
            isRecurring = projectEntity.IsRecurring,
            labels = projectEntity.ProjectProjectLabels
                .Select(x => LabelDTO.FromEntity(x.ProjectLabel)),
            services = projectEntity.ProjectServices
                .Select(x => ServiceItemDTO.FromEntity(x.Service)),
            workHours = projectEntity.WorkHours
                .Where(x => x.Duration != null)
                .Select(WorkHoursItemDTO.FromEntity)
        };
}