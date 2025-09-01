using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("orders")]
[Index("OrderNo", Name = "UQ__orders__465C81B8BF04BDFA", IsUnique = true)]
public partial class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_no")]
    [StringLength(100)]
    public string OrderNo { get; set; } = null!;

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("total_amount", TypeName = "decimal(18, 2)")]
    public decimal? TotalAmount { get; set; }

    [Column("shipping_address")]
    public string? ShippingAddress { get; set; }

    [Column("billing_address")]
    public string? BillingAddress { get; set; }

    [Column("payment_method")]
    [StringLength(100)]
    public string? PaymentMethod { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("placed_at")]
    public DateTime? PlacedAt { get; set; }

    [Column("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Order")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
