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

        /// <summary>所在都道府県（例：東京都）。画面のグループ表示・一括選択に使う。</summary>
        [Column("prefecture")]
        public string? Prefecture { get; set; }

        /// <summary>
        /// 血小板献血の取り扱いがないルームか。
        /// 先方ページは「取扱なし」も「その日満枠」も同じくタブ非活性になるため、
        /// HTMLからは区別できない。恒常的に取り扱いがないルームだけこのフラグで持つ。
        /// </summary>
        [Column("no_platelet")]
        public bool NoPlatelet { get; set; } = false;

        public virtual List<BloodDonationReserveCheck> BloodDonationReserveChecks { get; set; } = [];
    }
}
