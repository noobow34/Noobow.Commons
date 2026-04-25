using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ラジオ体操 動画キャッシュ
/// </summary>
[Table("radio_taiso_video")]
public class RadioTaisoVideo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>YouTube動画ID</summary>
    [Column("video_id")]
    [MaxLength(100)]
    public string VideoId { get; set; } = string.Empty;

    /// <summary>動画タイトル</summary>
    [Column("title")]
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;

    /// <summary>チャンネルID</summary>
    [Column("channel_id")]
    [MaxLength(100)]
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>チャンネル名</summary>
    [Column("channel_title")]
    [MaxLength(200)]
    public string ChannelTitle { get; set; } = string.Empty;

    /// <summary>サムネイルURL</summary>
    [Column("thumbnail_url")]
    [MaxLength(300)]
    public string ThumbnailUrl { get; set; } = string.Empty;

    /// <summary>再生数</summary>
    [Column("view_count")]
    public long ViewCount { get; set; }

    /// <summary>含まれる体操番号（例: "1,2,3"）Gemini判定結果。未判定は空文字</summary>
    [Column("taiso_numbers")]
    [MaxLength(10)]
    public string TaisoNumbers { get; set; } = string.Empty;

    /// <summary>AI判定済みフラグ（falseの間は選出対象外）</summary>
    [Column("ai_analyzed")]
    public bool AiAnalyzed { get; set; } = false;

    /// <summary>キャッシュ取得日時</summary>
    [Column("fetched_at")]
    public DateTime FetchedAt { get; set; } = DateTime.Now;

    public List<RadioTaisoHistory> RadioTaisoHistories { get; set; } = [];
}
