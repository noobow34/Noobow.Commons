using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// 献血トラッカー 手動制限レコード
/// </summary>
[Table("kenketsu_restriction")]
public class KenketsuRestriction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>制限開始日</summary>
    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    /// <summary>制限日数（1以上）</summary>
    [Column("duration_days")]
    public int DurationDays { get; set; }

    /// <summary>制限終了日（計算プロパティ）</summary>
    [NotMapped]
    public DateOnly EndDate => StartDate.AddDays(DurationDays - 1);

    /// <summary>理由・メモ</summary>
    [Column("reason")]
    [MaxLength(500)]
    public string? Reason { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    /// <summary>指定日がこの制限期間内かどうか</summary>
    public bool Contains(DateOnly date) => date >= StartDate && date <= EndDate;
}
