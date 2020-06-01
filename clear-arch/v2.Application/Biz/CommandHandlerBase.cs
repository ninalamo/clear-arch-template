using Core.Application.Common.Interfaces;

namespace Core.Application.Biz
{
    public abstract class CommandHandlerBase
    {
        protected readonly IApplicationDbContext dbContext;

        protected CommandHandlerBase(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}