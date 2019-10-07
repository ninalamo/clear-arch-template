using System;

namespace domain
{
    public class AuditTrail : BaseAudit
    {
        public long ID { get; set; }
        public string BeforeCommit { get; set; }
        public string AfterCommit { get; set; }
        public string Reason { get; set; }
        public string Table { get; set; }
        public long? ObjectID { get; set; }
    }
}
