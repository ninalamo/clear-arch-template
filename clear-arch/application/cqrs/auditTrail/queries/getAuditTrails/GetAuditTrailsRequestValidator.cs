using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.cqrs.auditTrail.queries
{
    public class GetAuditTrailsRequestValidator : AbstractValidator<GetAuditTrailsRequest>
    {
        public GetAuditTrailsRequestValidator()
        {
            
        }
    }
}
