using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("product_components")]
public partial class ProductComponent
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("component_id")]
    public int ComponentId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("note")]
    [StringLength(500)]
    public string? Note { get; set; }

    [ForeignKey("ComponentId")]
    [InverseProperty("ProductComponents")]
    public virtual Component Component { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("ProductComponents")]
    public virtual Product Product { get; set; } = null!;
}
