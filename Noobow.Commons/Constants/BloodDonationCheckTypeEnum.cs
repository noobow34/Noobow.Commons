using EnumStringValues;
using System.ComponentModel;

namespace Noobow.Commons.Constants
{
    public enum BloodDonationCheckTypeEnum
    {
        [Description("以前")]
        [StringValue("1")]
        BeforeAll,
        [Description("以後")]
        [StringValue("2")]
        AfterAll,
        [Description("ジャスト")]
        [StringValue("3")]
        Jsut
    }
}
