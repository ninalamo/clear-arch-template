using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Cards.Queries
{
    public class CheckBalanceHandler : QueryHandlerBase, IRequestHandler<CheckBalanceQuery, CheckBalanceResult>
    {
        public CheckBalanceHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<CheckBalanceResult> Handle(CheckBalanceQuery request, CancellationToken cancellationToken)
        {
            var card = await dbContext.Cards.FirstOrDefaultAsync(c => c.CardNumber == request.CardNumber.ToUpper());

            if (card == null) throw new NotFoundException(nameof(Card), request.CardNumber.ToUpper());

            return new CheckBalanceResult
            {
                Balance = card.Balance
            };
        }
    }

    public class CheckBalanceResult
    {
        public decimal Balance { get; set; }
    }

    public class CheckBalanceQuery : IRequest<CheckBalanceResult>
    {
        public string CardNumber { get; set; }
    }
}