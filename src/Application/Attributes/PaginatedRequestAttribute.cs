using FreelaFlowApi.Domain.Enums;

namespace FreelaFlowApi.Application.Attributes;
public class PaginatedRequestAttribute : Attribute 
{
    public PaginationTypeEnum paginationType { get; set; }
    public string Description { get; set; } = "";
    public Type Type { get; set; } = typeof(string);

    public PaginatedRequestAttribute(PaginationTypeEnum pagType) =>
        paginationType = pagType;

    public PaginatedRequestAttribute(string description, PaginationTypeEnum pagType) =>
        (Description, paginationType) = (description, pagType);

    public PaginatedRequestAttribute(string description, PaginationTypeEnum pagType, Type type) =>
        (Description, Type, paginationType) = (description, type, pagType);
}