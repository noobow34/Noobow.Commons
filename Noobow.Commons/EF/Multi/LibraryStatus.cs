using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi
{
    [Table("library_status")]
    public class LibraryStatus
    {
        [Key]
        [Column("book_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Column("book_name")]
        public string? BookName { get; set; }

        [Column("reservation_sequence")]
        public int? ReservationSequence { get; set; }

        [Column("reservation_sequence_changed_at")]
        public DateTime? ReservationSequenceChangedAt { get; set; }

        [Column("reservation_kind")]
        public string? ReservationKind { get; set; }

        [Column("reservation_kind_changed_at")]
        public DateTime? ReservationKindChangedAt { get; set; }

        [Column("reservation_status")]
        public string? ReservationStatus { get; set; }

        [Column("reservation_status_changed_at")]
        public DateTime? ReservationStatusChangedAt { get; set; }

        [Column("registered_at")]
        public DateTime? RegisteredAt { get; set; }
    }
}
