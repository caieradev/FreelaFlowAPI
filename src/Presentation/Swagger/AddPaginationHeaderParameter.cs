using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using FreelaFlowApi.Application.Attributes;
using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Presentation.Swagger;
public class AddPaginationHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();
        var parameters = new List<OpenApiParameter>();

        context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
        PaginatedRequestAttribute? paginatedAttribute = methodInfo.GetCustomAttribute<PaginatedRequestAttribute>();

        if (paginatedAttribute != null)
        {
            List<OpenApiParameter> paginationParameters = new();
            if (paginatedAttribute.paginationType != PaginationTypeEnum.SinglePage)
                paginationParameters.Add(new OpenApiParameter
                {
                    Description = paginatedAttribute.paginationType == PaginationTypeEnum.Offset ? "Número da página" : $"Cursor da página ({paginatedAttribute.Description}, {paginatedAttribute.Type.Name})",
                    Name = paginatedAttribute.paginationType == PaginationTypeEnum.Offset ? "X-Page" : "X-Cursor",
                    In = ParameterLocation.Header,
                    Required = false
                });
            paginationParameters.Add(new OpenApiParameter
            {
                Description = "Número de itens por página",
                Name = "X-PageSize",
                In = ParameterLocation.Header,
                Required = false
            });

            parameters.AddRange(paginationParameters);
        }

        parameters.AddRange(operation.Parameters.Where(x => x.Name != "api-version"));
        operation.Parameters = parameters;
    }
}