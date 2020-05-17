using application.cqrs._base;
using application.interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace application.cqrs.auditTrail.queries
{
    public class GetAuditTrailsRequestHandler : RequestHandlerBase, IRequestHandler<GetAuditTrailsRequest, GetAuditTrailsResponse>
    {
        public GetAuditTrailsRequestHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<GetAuditTrailsResponse> Handle(GetAuditTrailsRequest request, CancellationToken cancellationToken)
        {
            var total = dbContext.History.Count();
            var skip = request.GetSkip();
            var list = await dbContext.History.AsNoTracking().Skip(skip).Take(request.PageSize).ProjectTo<GetAuditTrailsDto>(mapper.ConfigurationProvider).ToArrayAsync();

            return new GetAuditTrailsResponse(list, request.PageNumber, request.PageSize, total);
        }
    }
}