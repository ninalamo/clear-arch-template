using application.cqrs._base;
using MediatR;

namespace application.cqrs.auditTrail.queries
{
    public class GetAuditTrailsRequest : PagedQueryRequestBase, IRequest<GetAuditTrailsResponse>
    {
    }
}