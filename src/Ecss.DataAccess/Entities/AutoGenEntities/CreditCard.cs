using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("credit_cards")]
public partial class CreditCard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("card_holder")]
    [StringLength(255)]
    public string? CardHolder { get; set; }

    [Column("card_type")]
    [StringLength(50)]
    public string? CardType { get; set; }

    [Column("last4")]
    [StringLength(4)]
    public string? Last4 { get; set; }

    [Column("expiry_month")]
    public byte? ExpiryMonth { get; set; }

    [Column("expiry_year")]
    public short? ExpiryYear { get; set; }

    [Column("token")]
    [StringLength(500)]
    public string? Token { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("CreditCards")]
    public virtual User User { get; set; } = null!;
}
