using AutoMapper;
using Core.Application.Common.Interfaces;

namespace Core.Application.Biz
{
    public abstract class QueryHandlerBase : CommandHandlerBase
    {
        protected readonly IMapper mapper;

        protected QueryHandlerBase(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }
    }
}
