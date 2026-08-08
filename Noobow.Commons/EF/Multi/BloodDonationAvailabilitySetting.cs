using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// 献血空き横断検索の前回検索条件。個人利用のため1行（id=1）だけを使い回す。
/// </summary>
[Table("blood_donation_availability_setting")]
public class BloodDonationAvailabilitySetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>前回選択していた献血ルームのCenterId（カンマ区切り）。</summary>
    [Column("center_ids")]
    public string? CenterIds { get; set; }

    /// <summary>前回検索した対象日。過ぎている場合は画面側で当日に読み替える。</summary>
    [Column("target_date")]
    public DateOnly? TargetDate { get; set; }

    /// <summary>
    /// 献血ルーム1件あたりの取得所要秒数の実測値（指数移動平均）。取得時間の目安表示に使う。
    /// 未計測ならnull。
    /// </summary>
    [Column("sec_per_room")]
    public double? SecPerRoom { get; set; }
}
