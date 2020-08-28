using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Cards.Commands
{
    public class ReloadCardHandler : CommandHandlerBase, IRequestHandler<ReloadCardCommand, ReloadCardResult>
    {
        public ReloadCardHandler(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ReloadCardResult> Handle(ReloadCardCommand request, CancellationToken cancellationToken)
        {
            var card = await dbContext.Cards.FirstOrDefaultAsync(i => i.CardNumber == request.CardNumber);

            if (card == null) throw new NotFoundException(nameof(Card), request.CardNumber);

            var balance = card.Balance;

            var limit = await dbContext.CardLimits.FirstOrDefaultAsync();



            if(balance + request.LoadAmount > limit.Maximum)
            {
                throw new System.Exception("Load limit reached.");
            }

            card.Balance += request.LoadAmount;

            var history = new CardTransactionHistory
            {
                Adjustment = request.LoadAmount,
                CardID = card.ID,
                Transaction = TransactionType.Reload,
            };

            dbContext.Cards.Update(card);

            dbContext.Transactions.Add(history);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new ReloadCardResult
            {
                Balance = card.Balance
            };
        }
    }

    public class ReloadCardResult
    {
        public decimal Balance { get; set; }
    }

    public class ReloadCardCommand : IRequest<ReloadCardResult>
    {
        public string CardNumber { get; set; }
        public decimal LoadAmount { get; set; }
    }
}