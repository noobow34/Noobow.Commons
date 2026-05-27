using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// スタンプカードテーブル。
/// is_manual=true  → 手動スタンプ
/// is_manual=false → 自動スタンプ非表示（override）
/// </summary>
[Table("stamp_card")]
public class StampCard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("stamp_date")]
    public DateOnly StampDate { get; set; }

    /// <summary>"radio_taiso" or "yoga"</summary>
    [Column("stamp_type")]
    public string StampType { get; set; } = string.Empty;

    /// <summary>true=手動スタンプ / false=自動スタンプ非表示(override)</summary>
    [Column("is_manual")]
    public bool IsManual { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}