using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ラジオ体操セレクター 監視対象チャンネル（Jobで新着動画を定期チェック）
/// </summary>
[Table("radio_taiso_watch_channel")]
public class RadioTaisoWatchChannel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>YouTubeチャンネルID</summary>
    [Column("channel_id")]
    [MaxLength(100)]
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>チャンネル名（表示用）</summary>
    [Column("channel_title")]
    [MaxLength(200)]
    public string ChannelTitle { get; set; } = string.Empty;

    /// <summary>登録日時</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
