using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ラジオ体操なし判定済み動画ID（再収集防止リスト）
/// radio_taiso_video には登録しないが、収集時に除外するために video_id のみ保持する
/// </summary>
[Table("radio_taiso_no_taiso_video")]
public class RadioTaisoNoTaisoVideo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>YouTube動画ID</summary>
    [Column("video_id")]
    [MaxLength(100)]
    public string VideoId { get; set; } = string.Empty;

    /// <summary>登録日時（AI判定日時）</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
