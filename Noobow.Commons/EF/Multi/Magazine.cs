using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Noobow.Commons.EF.Multi;

[Keyless]
[Table("magazine")]
public partial class Magazine
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("magazine_name")]
    [StringLength(100)]
    public string MagazineName { get; set; } = null!;

    [Column("publish_day")]
    public int PublishDay { get; set; }

    [Column("offset_month")]
    public int OffsetMonth { get; set; }

    [Column("cron_def")]
    [StringLength(100)]
    public required string CronDef { get; set; }

    [Column("enabled")]
    public required bool Enabled { get; set; }
}
