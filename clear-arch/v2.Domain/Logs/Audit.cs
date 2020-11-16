using Core.Domain.Interfaces;
using System;

namespace Core.Domain.Logs
{
    public class Audit : IKey<Guid>
    {
        public Audit()
        {
        }
        public Guid ID { get; set; }

        public DateTime AuditDateTimeUtc { get; set; }  /*Log time*/
        public string AuditType { get; set; }           /*Create, Update or Delete*/
        public string AuditUser { get; set; }           /*Log User*/
        public string TableName { get; set; }           /*Table where rows been 
                                                          created/updated/deleted*/
        public string KeyValues { get; set; }           /*Table Pk and it's values*/
        public string OldValues { get; set; }           /*Changed column name and old value*/
        public string NewValues { get; set; }           /*Changed column name 
                                                          and current value*/
        public string ChangedColumns { get; set; }
    }
}
