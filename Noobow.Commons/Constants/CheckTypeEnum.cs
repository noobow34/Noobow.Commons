﻿using EnumStringValues;

namespace Noobow.Commons.Constants
{
    public enum CheckTypeEnum
    {
        [StringValue("1")]
        ETag,

        [StringValue("2")]
        LastModified,

        [StringValue("3")]
        HtmlHash,

        [StringValue("4")]
        Xpath
    }
}
