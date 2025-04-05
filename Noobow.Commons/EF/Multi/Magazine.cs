using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("magazine")]
    public partial class Magazine
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("magazine_name")]
        [StringLength(100)]
        public string MagazineName { get; set; } = null!;

        [Column("publish_day")]
        public int PublishDay { get; set; }

        [Column("offset_month")]
        public int OffsetMonth { get; set; }

        [ForeignKey("SagamiharaLibraryUserInfo")]
        [Column("info_id")]
        public int InfoId { get; set; }

        public List<MagazineSchedule> MagazineSchedules { get; set; } = [];
    }
}