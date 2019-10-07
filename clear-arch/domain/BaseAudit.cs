using domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain
{
    public class BaseAudit : ICreditable, ITimeStamp, IActive
    {
        
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
