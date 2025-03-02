using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Noobow.Commons.EF.Multi
{
    [Table("scheduler_job")]
    public class SchedulerJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("job_id")]
        public int JobId { get; set; }

        [Required]
        [Column("class_name")]
        [MaxLength(200)]
        public string ClassName { get; set; } = string.Empty;

        public List<SchedulerSchedule> SchedulerSchedules { get; set; } = [];
    }
}
