using Core.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Persistence.Logs
{
    public class AuditEntry
    {
        public EntityEntry Entry { get; }
        public string AuditType { get; set; }
        public string AuditUser { get; set; }
        public string TableName { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        public List<string> ChangedColumns { get; } = new List<string>();

        public AuditEntry(EntityEntry entry, string auditUser)
        {
            Entry = entry;
            AuditUser = auditUser;
            SetChanges();
        }

        private void SetChanges()
        {
            TableName = Entry.Metadata.GetTableName();
            foreach (PropertyEntry property in Entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                string dbColumnName = property.Metadata.GetColumnName();

                if (property.Metadata.IsPrimaryKey())
                {
                    KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }

                AuditType = Entry.State.ToString();

                switch (Entry.State)
                {
                    case EntityState.Added:
                        NewValues[propertyName] = property.CurrentValue;
                        break;

                    case EntityState.Deleted:
                        OldValues[propertyName] = property.OriginalValue;
                        break;

                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            ChangedColumns.Add(dbColumnName);

                            OldValues[propertyName] = property.OriginalValue;
                            NewValues[propertyName] = property.CurrentValue;
                        }
                        break;
                }
            }
        }

        public Audit ToAudit()
        {
            var audit = new Audit
            {
                ID = Guid.NewGuid(),
                AuditDateTimeUtc = DateTime.UtcNow,
                AuditType = AuditType.ToString(),
                AuditUser = AuditUser,
                TableName = TableName,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ?
                              null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ?
                              null : JsonConvert.SerializeObject(NewValues),
                ChangedColumns = ChangedColumns.Count == 0 ?
                                   null : JsonConvert.SerializeObject(ChangedColumns)
            };

            return audit;
        }
    }
}