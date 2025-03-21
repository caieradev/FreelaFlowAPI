using FreelaFlowApi.Application.DTOs;
using System.Linq.Expressions;

namespace FreelaFlowApi.Application.Extensions;
public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginationDTO pagination, Expression<Func<T, bool>>? predicate = null)
    {
        if (pagination.cursor != null)
        {
            return query.ApplyCursorPagination(pagination.pageSize, predicate ?? throw new Exception("cursor não nulo e predicate nulo no ApplyPagination do repositório."));
        }
        return query.ApplyOffsetPagination(pagination.page, pagination.pageSize);
    }

    private static IQueryable<T> ApplyOffsetPagination<T>(this IQueryable<T> query, int page, int pageSize)
    {
        return query.Skip(page * pageSize).Take(pageSize);
    }

    private static IQueryable<T> ApplyCursorPagination<T>(this IQueryable<T> query, int pageSize, Expression<Func<T, bool>> predicate)
    {
        return query.Where(predicate).Take(pageSize);
    }
}