using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Entities;

[Table("search_logs")]
public partial class SearchLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("session_id")]
    [StringLength(255)]
    public string? SessionId { get; set; }

    [Column("query_text")]
    [StringLength(1000)]
    public string? QueryText { get; set; }

    [Column("filters")]
    public string? Filters { get; set; }

    [Column("result_count")]
    public int? ResultCount { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("SearchLogs")]
    public virtual User? User { get; set; }
}
