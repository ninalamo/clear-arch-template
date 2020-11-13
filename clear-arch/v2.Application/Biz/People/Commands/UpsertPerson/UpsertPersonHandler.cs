using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.People.Commands.UpsertPerson
{
    public class UpsertPersonHandler : CommandHandlerBase, IRequestHandler<UpsertPersonCommand, Guid>
    {
        public UpsertPersonHandler(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Guid> Handle(UpsertPersonCommand request, CancellationToken cancellationToken)
        {
            Person entity;
            if (request.PersonID.HasValue)
            {
                entity = await dbContext.People.FindAsync(request.PersonID.Value);

                Fill(request, entity);

                dbContext.People.Update(entity);
            }
            else
            {
                entity = new Person();
                dbContext.People.Add(entity);
                Fill(request, entity);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity.ID;
        }

        private static void Fill(UpsertPersonCommand request, Person entity)
        {
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            entity.NameSuffix = request.NameSuffix;
        }
    }

    public class HomeAddress
    {
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String ZipCode { get; set; }
    }
}