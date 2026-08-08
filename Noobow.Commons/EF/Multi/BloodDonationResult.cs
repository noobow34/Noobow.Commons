using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("blood_donation_result")]
    public class BloodDonationResult
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("donated_on")]
        public required DateOnly DonatedOn { get; set; }

        /// <summary>献血ルーム名。KenketsuNote（RoomName）由来。</summary>
        [Column("place")]
        public string? Place { get; set; }

        [Column("status")]
        public required string Status { get; set; } = "pending";

        [Column("attempts")]
        public int Attempts { get; set; } = 0;

        [Column("last_tried_at")]
        public DateTime? LastTriedAt { get; set; }

        public virtual List<BloodDonationResultItem> Items { get; set; } = [];
    }
}
