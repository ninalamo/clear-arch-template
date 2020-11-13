using Core.Application.Common.Interfaces;
using Core.Common;
using Core.Domain.Entities;
using Core.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Persistence.Logs;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService CurrentUserService;
        private readonly IDateTime _dateTime;

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardLimit> CardLimits { get; set; }
        public virtual DbSet<CardTransactionHistory> Transactions { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<BaseFare> Fares { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<CardDiscountHistory> DiscountHistories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options,
           ICurrentUserService currentUserService,
           IDateTime dateTime)
           : base(options)
        {
            CurrentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            new AuditHelper(this).Audit(CurrentUserService.UserID);


            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}