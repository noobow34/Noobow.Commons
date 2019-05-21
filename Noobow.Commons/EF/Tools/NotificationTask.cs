using Noobow.Commons.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Noobow.Commons.EF.Tools
{
    [Table("NOTIFICATION_TASK")]
    public class NotificationTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TASK_ID")]
        public int TaskId { get; set; }

        [Column("NOTIFICATION_DETAIL")]
        public string NotificationDetail { get; set; }

        [Column("NOTIFICATION_TIME")]
        public DateTime? NotificationTime { get; set; }

        [Column("STATUS")]
        public NotificationTaskStatusEnum Status { get; set; }
    }
}
