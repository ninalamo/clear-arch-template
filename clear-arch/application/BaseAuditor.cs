using application.interfaces;
using System;

namespace application
{
    public abstract class BaseAuditor : ITakeCredit
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //public static void Create(IErpDbContext _context, string creator, object before, object after, string table, long? id = null)
        //{
        //    try
        //    {
        //        _context.AuditTrails.Add(new AuditTrail
        //        {
        //            BeforeCommit = Auditify.ToJsonString(before),
        //            AfterCommit = Auditify.ToJsonString(after),
        //            CreatedBy = creator,
        //            ModifiedBy = creator,
        //            ObjectID = id,
        //            Table = table
        //        });

        //        _context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
        //    }
        //    catch
        //    {

        //    }

        //}
    }
}
