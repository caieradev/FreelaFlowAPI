using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Infrastructure.Database;
using FreelaFlowApi.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using FreelaFlowApi.Application.Extensions;

namespace FreelaFlowApi.Infrastructure.Repositories;
public abstract class BaseRepository<T> where T : class, IEntity
{
	protected readonly FreelaFlowApiDbContext _dbContext;
	protected readonly PaginationDTO _pagination;

	public BaseRepository(FreelaFlowApiDbContext dbContext, PaginationDTO? pagination = null) =>
		(_dbContext, _pagination) = (dbContext, pagination ?? new PaginationDTO());
}