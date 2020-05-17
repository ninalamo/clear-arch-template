using FluentValidation;

namespace application.cqrs.auditTrail.queries
{
    public class GetAuditTrailsRequestValidator : AbstractValidator<GetAuditTrailsRequest>
    {
        public GetAuditTrailsRequestValidator()
        {
        }
    }
}