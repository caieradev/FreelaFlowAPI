using FreelaFlowApi.Application.Extensions;
using Microsoft.AspNetCore.Http.Features;
using FreelaFlowApi.Application.Attributes;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Infrastructure.Middlewares;
public class PaginationHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, PaginationDTO _pagination)
    {
        PaginatedRequestAttribute? pagination = context.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata?.GetMetadata<PaginatedRequestAttribute>();

        if (pagination != null)
        {
            int? pageSize = context.Request.Headers["X-PageSize"].FirstOrDefault()?.TryParseInt32();
            int? page = context.Request.Headers["X-Page"].FirstOrDefault()?.TryParseInt32();
            string? cursor = context.Request.Headers["X-Cursor"].FirstOrDefault();

            if (pageSize != null)
            {
                _pagination.pageSize = pageSize.Value;
            }

            switch (pagination.paginationType)
            {
                case PaginationTypeEnum.Cursor:
                    if (page != null)
                        throw new Exception("Número de página informada em paginação por cursor.");
                    if (!String.IsNullOrEmpty(cursor))
                    {
                        var converter = System.ComponentModel.TypeDescriptor.GetConverter(pagination.Type);
                        object? result = null;
                        try
                        {
                            result = converter.ConvertFrom(cursor);
                            if (result == null)
                                throw new Exception($"Não foi possível converter o cursor {cursor} para o tipo esperado {pagination.Type.Name}.");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Cursor inválido, {pagination.Type} esperado.", ex);
                        }
                        _pagination.cursor = result;
                    }
                    break;
                case PaginationTypeEnum.Offset:
                    if (cursor != null)
                        throw new Exception("Cursor informado em paginação por número de página.");

                    if (page != null)
                        _pagination.page = page.Value;
                    break;
                case PaginationTypeEnum.SinglePage:
                    if (page != null)
                        throw new Exception("Número de página informado em requisição de página única.");
                    if (cursor != null)
                        throw new Exception("Cursor informado em requisição de página única.");
                    break;
            }
        }

        await _next(context);
    }
}