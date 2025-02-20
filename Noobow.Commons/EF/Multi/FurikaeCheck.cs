using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

[Table("furikae_check")]
public partial class FurikaeCheck
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("furikae_date")]
    public DateTime FurikaeDate { get; set; }

    [Column("notified")]
    public bool Notified { get; set; } = false;

    [Column("finished")]
    public bool Finished { get; set; } = false;

    [Column("schedule_id")]
    [StringLength(32)]
    public string? ScheduleId { get; set; }

    [Column("info_id")]
    public int InfoId { get;set; }
}
