using EnumStringValues;

namespace Noobow.Commons.Constants
{
    public enum NotificationTaskStatusEnum
    {
        [StringValue("0")]
        INITIAL,
        [StringValue("1")]
        EXECUTING,
        [StringValue("2")]
        EXECUTED
    }
}
