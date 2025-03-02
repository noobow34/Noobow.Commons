using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Noobow.Commons.EF.Multi
{
    [Table("scheduler_schedule")]
    public class SchedulerSchedule
    {
        [Key]
        [Column("schedule_id")]
        public int ScheduleId { get; set; }

        [ForeignKey("SchedulerJob")]
        [Column("job_id")]
        public int JobId { get; set; }
        public SchedulerJob SchedulerJob { get; set; } = null!;

        [Column("cron_def")]
        [Required]
        [MaxLength(100)]
        public string CronDef { get; set; } = string.Empty;

        [Column("enabled")]
        public bool Enabled { get; set; } = true;
    }
}
