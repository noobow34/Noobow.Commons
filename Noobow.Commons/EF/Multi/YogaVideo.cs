using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ヨガセレクター 動画キャッシュ
/// </summary>
[Table("yoga_video")]
public class YogaVideo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("yoga_channel_id")]
    public int YogaChannelId { get; set; }

    /// <summary>YouTube動画ID</summary>
    [Column("video_id")]
    [MaxLength(100)]
    public string VideoId { get; set; } = string.Empty;

    /// <summary>動画タイトル</summary>
    [Column("title")]
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;

    /// <summary>サムネイルURL</summary>
    [Column("thumbnail_url")]
    [MaxLength(300)]
    public string ThumbnailUrl { get; set; } = string.Empty;

    /// <summary>動画の長さ（秒）</summary>
    [Column("duration_seconds")]
    public int DurationSeconds { get; set; }

    /// <summary>キャッシュ取得日時</summary>
    [Column("fetched_at")]
    public DateTime FetchedAt { get; set; } = DateTime.Now;

    /// <summary>選出対象から除外フラグ</summary>
    [Column("excluded")]
    public bool Excluded { get; set; } = false;

    public YogaChannel? YogaChannel { get; set; }
    public List<YogaHistory> YogaHistories { get; set; } = [];
}
