using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Fares.Queries
{
    public class GetFareHandler : QueryHandlerBase, IRequestHandler<GetFareQuery, GetFareResult>
    {
        public GetFareHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<GetFareResult> Handle(GetFareQuery request, CancellationToken cancellationToken)
        {

            var points = await dbContext.Stations
                .OrderBy(i => i.ID)
                .Where(i =>
                    (i.ID >= request.PickUp && i.ID <= request.DropOff) ||
                    i.ID >= request.DropOff && i.ID <= request.PickUp)
                .ToListAsync();


            var baseFare = await dbContext.Fares.FirstOrDefaultAsync(i => i.IsActive);

            var fare = points.Sum(i => i.ToNext) - points.First().ToNext;

            return new GetFareResult
            {
                Amount = baseFare.Amount + fare
            };

        }
    }

    public class GetFareResult
    {
        public decimal Amount { get; set; }
    }

    public class GetFareQuery : IRequest<GetFareResult>
    {
        public int PickUp { get; set; }
        public int DropOff { get; set; }
    }
}
