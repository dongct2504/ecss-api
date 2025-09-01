using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("product_suppliers")]
[Index("ProductId", "SupplierId", Name = "UQ_product_supplier", IsUnique = true)]
public partial class ProductSupplier
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("supplier_id")]
    public int SupplierId { get; set; }

    [Column("supplier_sku")]
    [StringLength(200)]
    public string? SupplierSku { get; set; }

    [Column("cost_price", TypeName = "decimal(18, 2)")]
    public decimal? CostPrice { get; set; }

    [Column("lead_time_days")]
    public int? LeadTimeDays { get; set; }

    [Column("min_order_qty")]
    public int? MinOrderQty { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductSuppliers")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SupplierId")]
    [InverseProperty("ProductSuppliers")]
    public virtual Supplier Supplier { get; set; } = null!;
}
