using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities
{
    public class JobRequirement : Auditable<Guid>
    {
        public string Title { get; set; }
        public string ReportsTo { get; set; }
    
    }
}
