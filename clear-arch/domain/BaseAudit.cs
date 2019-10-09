using System;
using lib.common.interfaces;

namespace domain
{
    public class BaseAudit : ITakeCredit, ITimeStamp, IActive
    {
        
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
