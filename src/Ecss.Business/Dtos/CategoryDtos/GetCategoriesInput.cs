namespace Ecss.Business.Dtos.CategoryDtos;

public class GetCategoriesInput : DefaultInput
{
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public DateTime? CreatedAt { get; set; }
}
