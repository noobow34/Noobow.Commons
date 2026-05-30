using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// 献血トラッカー 設定（シングルトン1レコード運用）
/// </summary>
[Table("kenketsu_setting")]
public class KenketsuSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>性別: male / female（現在は male 固定）</summary>
    [Column("sex")]
    [MaxLength(10)]
    public string Sex { get; set; } = "male";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
