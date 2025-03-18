using FreelaFlowApi.Domain.Entities;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.DTOs;
public struct ProposalItemDTO
{
    public Guid id { get; set; }
    public KeyValuePair<ProposalStatusEnum, string> status { get; set; }
    public decimal? fixedPrice { get; set; }
    public decimal? hourlyRate { get; set; }


    internal static ProposalItemDTO FromEntity(ProposalEntity entity) =>
        new()
        {
            id = entity.Id,
            status = new KeyValuePair<ProposalStatusEnum, string>(entity.Status, entity.Status.ToString()),
            fixedPrice = entity.FixedPrice,
            hourlyRate = entity.HourlyRate
        };

    internal static IEnumerable<ProposalItemDTO> FromEntity(IEnumerable<ProposalEntity> enumerable)
    {
        throw new NotImplementedException();
    }
}