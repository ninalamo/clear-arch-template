using System;

namespace lib.common.interfaces
{
    public interface ITimeStamp
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset ModifiedOn { get; set; }
    }
}