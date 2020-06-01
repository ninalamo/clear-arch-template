using Core.Application.Common.Interfaces;
using Core.Common;
using Core.Domain.Common;
using Core.Domain.Common.Interfaces;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public virtual DbSet<Person> People { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public ApplicationDbContext(
        //   DbContextOptions<ApplicationDbContext> options,
        //   ICurrentUserService currentUserService,
        //   IDateTime dateTime)
        //   : base(options)
        //{
        //    _currentUserService = currentUserService;
        //    _dateTime = dateTime;
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedOn = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.ModifiedBy = _currentUserService.UserId;
                        entry.Entity.ModifiedOn = DateTimeOffset.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}