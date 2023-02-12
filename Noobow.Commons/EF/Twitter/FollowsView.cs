using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Twitter
{
    [Table("FOLLOWS_VIEW")]
    public class FollowsView
    {

        [Key]
        [Column("EVENT_ID")]
        public int EventId { get; set; }

        [Column("OWNER")]
        public string Owner { get; set; }

        [Column("EVENT_DATE")]
        public DateTime EventDate { get; set; }

        [Column("EVENT_DATE_STRING")]
        public string EventDateString { get; set; }

        [Column("FOLLOWS_TYPE")]
        public string FollowsType { get; set; }

        [Column("EVENT_TYPE")]
        public string EventType { get; set; }

        [Column("SCREEN_NAME")]
        public string ScreenName { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("SAME_HISTORY_COUNT")]
        public int? SameHistoryCount { get; set; }

        [NotMapped]
        public string EventDateDisp { get { return EventDate.ToString("MM/dd HH:mm"); } }

    }
}
