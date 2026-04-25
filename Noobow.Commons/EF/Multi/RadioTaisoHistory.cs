using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ラジオ体操 選出履歴（チャンネル分散のために使用）
/// </summary>
[Table("radio_taiso_history")]
public class RadioTaisoHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>選出日</summary>
    [Column("selected_date")]
    public DateOnly SelectedDate { get; set; }

    /// <summary>動画キャッシュへの外部キー</summary>
    [Column("radio_taiso_video_id")]
    public int RadioTaisoVideoId { get; set; }

    /// <summary>登録日時</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public RadioTaisoVideo? RadioTaisoVideo { get; set; }
}
