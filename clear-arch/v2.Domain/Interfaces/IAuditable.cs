using System;

namespace Core.Domain.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
