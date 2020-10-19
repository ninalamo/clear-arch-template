using Core.Domain.Entities;
using Core.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> People { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        ChangeTracker ChangeTracker { get; }
        DbSet<Audit> Audits { get; set; }
        DbSet<Event> Events { get; set; }
       
    }
}


