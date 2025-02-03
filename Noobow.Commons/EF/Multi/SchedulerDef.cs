using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

[Table("scheduler_def")]
public partial class SchedulerDef
{
    [Key]
    [Column("class_name")]
    [StringLength(200)]
    public string ClassName { get; set; } = null!;

    [Column("cron_def")]
    [StringLength(100)]
    public required string CronDef { get; set; }

    [Column("enabled")]
    public required bool Enabled { get;set; }
}
