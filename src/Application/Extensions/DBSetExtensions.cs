using FreelaFlowApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelaFlowApi.Application.Extensions;
public static class DBSetExtensions
{
    public static IQueryable<T> IsActive<T>(this DbSet<T> query) where T : class, IEntity =>
        query.Where(x => x.Active);
}