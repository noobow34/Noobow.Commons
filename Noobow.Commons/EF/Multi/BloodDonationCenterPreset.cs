using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// 献血空き横断検索の献血ルーム選択セット（「自宅周辺」「出張:大阪」など）。
/// 全国のルームから毎回選び直さずに済むよう、名前を付けて保存しておく。
/// </summary>
[Table("blood_donation_center_preset")]
public class BloodDonationCenterPreset
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>セット名。同名は上書き扱いにするため実質ユニーク。</summary>
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>このセットに含まれる献血ルームのCenterId（カンマ区切り）。</summary>
    [Column("center_ids")]
    public string? CenterIds { get; set; }
}
