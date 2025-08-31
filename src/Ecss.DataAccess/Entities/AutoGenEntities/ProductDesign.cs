using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("product_designs")]
public partial class ProductDesign
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("option_type")]
    [StringLength(50)]
    public string? OptionType { get; set; }

    [Column("required")]
    public bool Required { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductDesigns")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Design")]
    public virtual ICollection<ProductDesignOption> ProductDesignOptions { get; set; } = new List<ProductDesignOption>();
}
