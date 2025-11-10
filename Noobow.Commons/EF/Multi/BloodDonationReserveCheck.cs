using Noobow.Commons.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("blood_donation_reserve_check")]
    public class BloodDonationReserveCheck
    {
        [Key]
        [Column("check_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckId { get; set; }

        [Column("check_type")]
        public required BloodDonationCheckTypeEnum CheckType { get; set; }

        [Column("check_date")]
        public required DateTime CheckDate { get; set; }

        [ForeignKey("BloodDonationCenter")]
        [Column("center_id")]
        public required int CenterId { get; set; }

        public BloodDonationCenter BloodDonationCenter { get; set; } = null!;

        [Column("donation_type")]
        public required BloodDonationTypeEnum DonationType { get; set; }

        [Column("finished")]
        public required bool Finished { get; set; } = false;
    }
}
