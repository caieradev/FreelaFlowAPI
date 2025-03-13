namespace FreelaFlowApi.Application.Interfaces;
public interface IEntity
{
    Guid Id { get; set; }
    bool Active { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}