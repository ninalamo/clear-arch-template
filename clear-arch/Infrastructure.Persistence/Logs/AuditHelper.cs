using Core.Application.Common.Interfaces;
using Core.Domain.Interfaces;
using Core.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Logs
{
    internal class AuditHelper
    {
        private readonly IApplicationDbContext dbContext;

        public AuditHelper(IApplicationDbContext db)
        {
            dbContext = db;
        }

        public void Audit(string userName)
        {
            dbContext.ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = new List<AuditEntry>();
            foreach (EntityEntry entry in dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is Audit
                    || entry.Entity is Event
                    || entry.State == EntityState.Detached
                    || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                auditEntries.Add(new AuditEntry(entry, userName));

                if (entry.Entity is IAuditable auditable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditable.CreatedBy = userName;
                            auditable.CreatedOn = DateTimeOffset.Now;
                            break;

                        case EntityState.Modified:
                            auditable.ModifiedBy = userName;
                            auditable.ModifiedOn = DateTimeOffset.Now;
                            break;

                        case EntityState.Deleted:
                            break;
                    }
                }
            }

            if (auditEntries.Any())
            {
                var logs = auditEntries.Select(x => x.ToAudit());
                dbContext.Audits.AddRange(logs);
            }
        }
    }
}