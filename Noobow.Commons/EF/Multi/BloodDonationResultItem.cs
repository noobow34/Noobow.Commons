using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("blood_donation_result_item")]
    public class BloodDonationResultItem
    {
        [Column("donated_on")]
        public required DateOnly DonatedOn { get; set; }

        [Column("item")]
        public required string Item { get; set; }

        [Column("value")]
        public required decimal Value { get; set; }

        public virtual BloodDonationResult BloodDonationResult { get; set; } = null!;
    }
}
