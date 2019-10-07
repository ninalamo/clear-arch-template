using System;
using System.Collections.Generic;
using System.Text;

namespace domain.interfaces
{
    public interface ITimeStamp
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset ModifiedOn { get; set; }
    }
}
