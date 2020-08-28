using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Fares.Queries
{
    public class GetStationsHandler : QueryHandlerBase, IRequestHandler<GetStationsQuery, GetStationsResult>
    {
        public GetStationsHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<GetStationsResult> Handle(GetStationsQuery request, CancellationToken cancellationToken)
        {
            var stations = await dbContext.Stations.AsNoTracking().Select(s => new StationDTO
            {
                Station = s.Name,
                Km = s.ToNext,
                ID = s.ID
            }).ToArrayAsync();

            return new GetStationsResult
            {
                Stations = stations
            };
        }
    }

    public class GetStationsQuery : IRequest<GetStationsResult>
    {
    }

    public class GetStationsResult
    {
        public IEnumerable<StationDTO> Stations { get; set; }
    }

    public class StationDTO
    {
        public string Station { get; set; }
        public int ID { get; set; }
        public int Km { get; set; }
    }
}