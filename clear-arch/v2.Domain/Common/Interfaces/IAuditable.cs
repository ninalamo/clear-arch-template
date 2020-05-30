using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Common.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
