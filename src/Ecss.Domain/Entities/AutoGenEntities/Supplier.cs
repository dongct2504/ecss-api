using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("suppliers")]
public partial class Supplier
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("contact_name")]
    [StringLength(255)]
    public string? ContactName { get; set; }

    [Column("phone")]
    [StringLength(50)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("website")]
    [StringLength(255)]
    public string? Website { get; set; }

    [Column("rating", TypeName = "decimal(3, 2)")]
    public decimal? Rating { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("contract_start")]
    public DateTime? ContractStart { get; set; }

    [Column("contract_end")]
    public DateTime? ContractEnd { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
}
