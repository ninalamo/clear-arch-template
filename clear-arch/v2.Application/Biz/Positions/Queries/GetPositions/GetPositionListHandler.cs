using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Core.Application.PositionsDTO;

namespace Core.Application.Biz.Positions.Queries
{
    public class GetPositionListHandler : QueryHandlerBase, IRequestHandler<GetPositionQuery, GetPositionResult>
    {
        public GetPositionListHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<GetPositionResult> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var positions = await dbContext.Positions
                .Select(i => new PositionsDTO { Code = i.Code, Name = i.Name })
                .ToArrayAsync();

            return new GetPositionResult
            {
                Positions = positions
            };
        }
    }
}

