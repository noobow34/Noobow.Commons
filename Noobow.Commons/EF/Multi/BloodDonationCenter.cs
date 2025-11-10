using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("blood_donation_center")]
    public partial class BloodDonationCenter
    {
        [Key]
        [Column("center_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CenterId { get; set; }

        [Column("center_name")]
        public string? CenterName { get; set; }

        [Column("place_id")]
        public string? PlaceId { get; set; }

        public virtual List<BloodDonationReserveCheck> BloodDonationReserveChecks { get; set; } = [];
    }
}
