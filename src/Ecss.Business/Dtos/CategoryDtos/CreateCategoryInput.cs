using System.ComponentModel.DataAnnotations;

namespace Ecss.Business.Dtos.CategoryDtos;

public class CreateCategoryInput
{
    public int? ParentId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [MaxLength(200)]
    public string? Slug { get; set; }

    public string? Description { get; set; }
}
