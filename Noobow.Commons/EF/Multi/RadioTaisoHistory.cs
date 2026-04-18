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

    /// <summary>YouTubeチャンネルID</summary>
    [Column("channel_id")]
    [MaxLength(100)]
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>YouTubeチャンネル名</summary>
    [Column("channel_title")]
    [MaxLength(200)]
    public string ChannelTitle { get; set; } = string.Empty;

    /// <summary>動画ID（カンマ区切りで複数可）</summary>
    [Column("video_ids")]
    [MaxLength(500)]
    public string VideoIds { get; set; } = string.Empty;

    /// <summary>動画タイトル（カンマ区切りで複数可）</summary>
    [Column("video_titles")]
    [MaxLength(1000)]
    public string VideoTitles { get; set; } = string.Empty;

    /// <summary>含まれているラジオ体操の番号（例: "1,2,3"）</summary>
    [Column("taiso_numbers")]
    [MaxLength(10)]
    public string TaisoNumbers { get; set; } = string.Empty;

    /// <summary>登録日時</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
