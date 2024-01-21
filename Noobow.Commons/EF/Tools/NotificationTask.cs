using Noobow.Commons.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Tools
{
    [Table("notification_task")]
    public class NotificationTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("notification_detail")]
        public string NotificationDetail { get; set; }

        [Column("notification_time")]
        public DateTime? NotificationTime { get; set; }

        [Column("status")]
        public NotificationTaskStatusEnum Status { get; set; }

        [Column("notification_to")]
        public string NotificationTo { get; set; }
    }
}
