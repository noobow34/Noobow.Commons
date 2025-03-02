using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Noobow.Commons.EF.Multi
{
    [Table("magazine_schedule")]
    public class MagazineSchedule
    {
        [Key]
        [Column("schedule_id")]
        public int ScheduleId { get; set; }

        [ForeignKey("Magazine")]
        [Column("magazine_id")]
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; } = null!;

        [Column("cron_def")]
        [Required]
        [MaxLength(100)]
        public string CronDef { get; set; } = string.Empty;

        [Column("enabled")]
        public bool Enabled { get; set; } = true;
    }
}
