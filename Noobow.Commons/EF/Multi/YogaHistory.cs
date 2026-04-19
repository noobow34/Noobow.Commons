using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

/// <summary>
/// ヨガセレクター 選出履歴（被り防止）
/// </summary>
[Table("yoga_history")]
public class YogaHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("yoga_video_id")]
    public int YogaVideoId { get; set; }

    /// <summary>選出日</summary>
    [Column("selected_date")]
    public DateOnly SelectedDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public YogaVideo? YogaVideo { get; set; }
}
