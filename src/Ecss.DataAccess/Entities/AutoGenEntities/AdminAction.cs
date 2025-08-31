using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("admin_actions")]
public partial class AdminAction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("admin_id")]
    public int? AdminId { get; set; }

    [Column("action")]
    [StringLength(255)]
    public string? Action { get; set; }

    [Column("target_table")]
    [StringLength(255)]
    public string? TargetTable { get; set; }

    [Column("target_id")]
    public int? TargetId { get; set; }

    [Column("detail")]
    public string? Detail { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("AdminActions")]
    public virtual User? Admin { get; set; }
}
