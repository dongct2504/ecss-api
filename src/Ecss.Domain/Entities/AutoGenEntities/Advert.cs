using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Entities;

[Table("adverts")]
public partial class Advert
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string? Title { get; set; }

    [Column("image_url")]
    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [Column("link")]
    [StringLength(500)]
    public string? Link { get; set; }

    [Column("position")]
    [StringLength(100)]
    public string? Position { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Adverts")]
    public virtual Company? Company { get; set; }
}
