using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noobow.Commons.EF.Workshop
{
    [Table("PERFORMANCE_TEST")]
    public class PerformanceTest
    {
        [Key]
        [Column("KEY_COLUMN")]
        public string KeyColumn { get; set; }
        [Column("VALUE_COLUMN")]
        public string ValueColumn { get; set; }
    }
}
