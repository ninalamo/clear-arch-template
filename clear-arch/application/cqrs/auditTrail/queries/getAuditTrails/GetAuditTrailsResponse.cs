using System.Collections.Generic;
using application.cqrs._base;
using application.interfaces.mapping;
using AutoMapper;
using domain;

namespace application.cqrs.auditTrail.queries
{
    public class GetAuditTrailsResponse : PagedQueryResponseBase<GetAuditTrailsDto>
    {
        public GetAuditTrailsResponse(IEnumerable<GetAuditTrailsDto> items, int pageNo, int pageSize, long totalRecordCount) : base(items, pageNo, pageSize, totalRecordCount)
        {
        }

    }

    public class GetAuditTrailsDto : IHaveCustomMapping
    {
        public string BeforeCommit { get; set; }
        public string AfterCommit { get; set; }
        public string Reason { get; set; }
        public string Table { get; set; }
        public long? ObjectID { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<AuditTrail, GetAuditTrailsDto>();
        }
    }
}