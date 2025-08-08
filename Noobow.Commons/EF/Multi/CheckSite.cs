using Noobow.Commons.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("check_site")]
    public class CheckSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("site_id")]
        public int SiteId { get; set; }

        [Column("url")]
        public string? Url { get; set; }

        [Column("site_name")]
        public string? SiteName { get; set; }

        [Column("check_type")]
        public CheckTypeEnum? CheckType { get; set; }

        [Column("check_identifier")]
        public string? CheckIdentifier { get; set; }

        [Column("last_check")]
        public DateTime? LastCheck { get; set; }

        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }

        [Column("schedule")]
        public string? Schedule { get; set; }

        [Column("xpath")]
        public string? Xpath { get; set; }

        [Column("enabled")]
        public bool Enabled { get; set; } = true;

        [Column("terminate_text")]
        public string? TerminateText { get; set; }
    }
}
