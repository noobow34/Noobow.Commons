﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("megalos_user_info")]
    public partial class MegalosUserInfo
    {
        [Key]
        [Column("info_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InfoId { get; set; }

        [Column("user_id")]
        public required string UserId { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("kind_id")]
        public required string KindId { get; set; }
    }
}
