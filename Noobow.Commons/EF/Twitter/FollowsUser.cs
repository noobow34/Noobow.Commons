using Noobow.Commons.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Noobow.Commons.EF.Twitter
{
    [Table("FOLLOWS_USER")]
    public class FollowsUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FOLLOWS_ID")]
        public int FollowsId { get; set; }

        [Column("OWNER")]
        public string Owner { get; set; }

        [Column("USER_ID")]
        public long? UserId { get; set; }

        [Column("SCREEN_NAME")]
        public string ScreenName { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("FOLLOWS_TYPE")]
        public FollowsTypeEnum FollowsType { get; set; }

        [Column("STATUS")]
        public FollowsStatusEnum Status { get; set; }

    }
}
