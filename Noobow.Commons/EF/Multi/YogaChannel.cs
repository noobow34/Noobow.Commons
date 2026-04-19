using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ヨガセレクター 対象チャンネル
/// </summary>
[Table("yoga_channel")]
public class YogaChannel
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

    public List<YogaVideo> YogaVideos { get; set; } = [];
}
