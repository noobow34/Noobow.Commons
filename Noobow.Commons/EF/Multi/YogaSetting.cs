using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ヨガセレクター 設定
/// </summary>
[Table("yoga_setting")]
public class YogaSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>被り防止日数（この日数以内に使った動画は除外）</summary>
    [Column("avoid_days")]
    public int AvoidDays { get; set; } = 14;

    /// <summary>最低合計時間（秒）</summary>
    [Column("min_duration_seconds")]
    public int MinDurationSeconds { get; set; } = 900; // デフォルト15分
}
