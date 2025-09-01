using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("components")]
[Index("Sku", Name = "UQ__componen__DDDF4BE740EB9302", IsUnique = true)]
public partial class Component
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    [StringLength(100)]
    public string? Type { get; set; }

    [Column("sku")]
    [StringLength(100)]
    public string? Sku { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("unit_price", TypeName = "decimal(18, 2)")]
    public decimal? UnitPrice { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("image_url")]
    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Component")]
    public virtual ICollection<ProductComponent> ProductComponents { get; set; } = new List<ProductComponent>();

    [InverseProperty("LinkedComponent")]
    public virtual ICollection<ProductDesignOption> ProductDesignOptions { get; set; } = new List<ProductDesignOption>();
}
