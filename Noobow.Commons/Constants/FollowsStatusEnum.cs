using EnumStringValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noobow.Commons.Constants
{
    public enum FollowsStatusEnum
    {
        [StringValue("1")]
        Active,
        [StringValue("0")]
        Inactive
    }
}
