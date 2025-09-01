namespace Ecss.Business.Dtos.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
}
