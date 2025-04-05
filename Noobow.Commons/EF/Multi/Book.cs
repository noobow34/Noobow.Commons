using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Multi;

[Table("book")]
public partial class Book
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("book_name")]
    public string BookName { get; set; } = null!;

    [Column("complete_date")]
    public DateTime? CompleteDate { get; set; }

    [Column("lastprocess_date")]
    public DateTime? LastprocessDate { get; set; }

    [Column("user_info_id")]
    public int UserInfoId { get; set; }
}
