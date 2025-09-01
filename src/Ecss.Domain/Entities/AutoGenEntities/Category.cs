using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("categories")]
[Index("Slug", Name = "UQ__categori__32DD1E4C3C19C128", IsUnique = true)]
public partial class Category
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("slug")]
    [StringLength(200)]
    public string? Slug { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Category? Parent { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
