using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ラジオ体操セレクター 設定
/// </summary>
[Table("radio_taiso_setting")]
public class RadioTaisoSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>チャンネル被り防止日数</summary>
    [Column("channel_avoid_days")]
    public int ChannelAvoidDays { get; set; } = 3;

    /// <summary>動画被り防止日数</summary>
    [Column("video_avoid_days")]
    public int VideoAvoidDays { get; set; } = 30;
}
