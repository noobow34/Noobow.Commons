using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

[Table("magazine_history")]
public partial class MagazineHistory
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("magazine_id")]
    public int MagazineId { get; set; }

    [Column("magazine_year")]
    public int MagazineYear { get; set; }

    [Column("magazine_month")]
    public int MagazineMonth { get; set; }

    [Column("exec_year")]
    public int ExecYear { get; set; }

    [Column("exec_month")]
    public int ExecMonth { get; set; }

    [Column("complete_date")]
    public DateTime? CompleteDate { get; set; }

    [Column("lastprocess_date")]
    public DateTime? LastprocessDate { get; set; }
}
