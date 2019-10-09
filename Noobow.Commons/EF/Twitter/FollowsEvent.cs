using Noobow.Commons.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Twitter
{
    [Table("FOLLOWS_EVENT")]
    public class FollowsEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EVENT_ID")]
        public int EventId { get; set; }

        [Column("FOLLOWS_ID")]
        public int FollowsId { get; set; }

        [Column("EVENT_DATE")]
        public DateTime EventDate { get; set; }

        [Column("EVENT_TYPE")]
        public FollowsEventTypeEnum EventType { get; set; }

        [Column("SAME_HISTORY_COUNT")]
        public int SameHistoryCount { get; set; }
    }
}
