using EnumStringValues;
using System.ComponentModel;

namespace Noobow.Commons.Constants
{
    public enum BloodDonationCheckTypeEnum
    {
        [Description("より前")]
        [StringValue("1")]
        BeforeAll,
        [Description("より後")]
        [StringValue("2")]
        AfterAll,
        [Description("ジャスト")]
        [StringValue("3")]
        Jsut
    }
}
