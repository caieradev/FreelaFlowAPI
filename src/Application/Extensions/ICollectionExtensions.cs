using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Application.Extensions;
public static class ICollectionExtensions
{
    public static IQueryable<T> IsActive<T>(this ICollection<T> collection) where T : class, IEntity =>
        collection
            .Where(x => x.Active)
            .AsQueryable();
}