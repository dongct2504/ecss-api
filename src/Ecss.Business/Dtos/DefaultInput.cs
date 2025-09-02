using Ecss.Common.Enums;

namespace Ecss.Business.Dtos;

public class DefaultInput
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;

    public string? SortBy { get; set; }
    public OrderByEnum? OrderBy { get; set; }
}
