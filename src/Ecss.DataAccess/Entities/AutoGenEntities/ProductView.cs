using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("product_views")]
public partial class ProductView
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("session_id")]
    [StringLength(255)]
    public string? SessionId { get; set; }

    [Column("viewed_at")]
    public DateTime ViewedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductViews")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ProductViews")]
    public virtual User? User { get; set; }
}
