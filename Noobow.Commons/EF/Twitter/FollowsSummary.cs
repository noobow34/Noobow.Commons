using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Twitter
{
    [Table("FOLLOWS_SUMMARY")]
    public class FollowsSummary
    {
        [Key]
        [Column("DATE")]
        public string Date { get; set; }

        [NotMapped]
        public string DateDisp { get { return Date?.Substring(4, 2) + "/" + Date?.Substring(6, 2); } }

        [Column("NOOBOW_FOLLOWER_DO")]
        public int NoobowFollowerDo { get; set; }

        [Column("NOOBOW_FOLLOWER_UN")]
        public int NoobowFollowerUn { get; set; }

        [Column("NOOBOW_FOLLOWING_DO")]
        public int NoobowFollowingrDo { get; set; }

        [Column("NOOBOW_FOLLOWING_UN")]
        public int NoobowFollowingUn { get; set; }

        [Column("JAFLEET_FOLLOWER_DO")]
        public int JafleetFollowerDo { get; set; }

        [Column("JAFLEET_FOLLOWER_UN")]
        public int JafleetFollowerUn { get; set; }

        [Column("JAFLEET_FOLLOWING_DO")]
        public int JafleetFollowingrDo { get; set; }

        [Column("JAFLEET_FOLLOWING_UN")]
        public int JafleetFollowingUn { get; set; }

    }
}
