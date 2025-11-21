using EnumStringValues;
using System.ComponentModel;

namespace Noobow.Commons.Constants
{
    public enum BloodDonationTypeEnum
    {
        [Description("全血400")]
        [StringValue("1")]
        Whole400,

        [Description("血漿")]
        [StringValue("2")]
        PPP,

        [Description("血小板")]
        [StringValue("3")]
        PCPPP,

        [Description("成分全て")]
        [StringValue("4")]
        ComponentAll,

        [Description("全種")]
        [StringValue("5")]
        All
    }
}
