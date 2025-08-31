using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("product_design_options")]
public partial class ProductDesignOption
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("design_id")]
    public int DesignId { get; set; }

    [Column("label")]
    [StringLength(255)]
    public string? Label { get; set; }

    [Column("sku")]
    [StringLength(100)]
    public string? Sku { get; set; }

    [Column("additional_price", TypeName = "decimal(18, 2)")]
    public decimal AdditionalPrice { get; set; }

    [Column("linked_component_id")]
    public int? LinkedComponentId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("DesignId")]
    [InverseProperty("ProductDesignOptions")]
    public virtual ProductDesign Design { get; set; } = null!;

    [ForeignKey("LinkedComponentId")]
    [InverseProperty("ProductDesignOptions")]
    public virtual Component? LinkedComponent { get; set; }
}
