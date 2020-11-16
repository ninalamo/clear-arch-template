using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Cards.Commands
{
    public class PayWithCardHandler : CommandHandlerBase, IRequestHandler<PayWithCardCommand, PayWithCardResult>
    {
        public PayWithCardHandler(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PayWithCardResult> Handle(PayWithCardCommand request, CancellationToken cancellationToken)
        {
            var card = await dbContext.Cards.FirstOrDefaultAsync(c => c.CardNumber == request.CardNumber.ToUpper());

            if (card == null) throw new NotFoundException(nameof(Card), request.CardNumber);

            if (!card.IsValid) throw new BadRequestException("Card is expired or invalid.");

            //check if has history for discount today
            var history = dbContext.DiscountHistories
                .AsNoTracking()
                .Where(i => i.CurrentDate.Date == DateTimeOffset.Now.Date);

            var amount = 0M;
            var discount = 0D;

            if (history == null)
            {
                discount = (await dbContext.Discounts.FirstOrDefaultAsync(d =>
                    d.Name == (card.DiscountType == CardType.Discounted ? "X5" : "X0"))).Percent;
            }
            else if (history.Count() <= 5 && history.Count() > 0)
            {
                discount = dbContext.Discounts.Where(d =>
                    d.Name == (card.DiscountType == CardType.Discounted ? "X5" : "X0") ||
                    d.Name == "X4")
                    .Sum(d => d.Percent);
            }
            else
            {
                discount = 0;
            }

            amount = request.Amount - (request.Amount * (decimal)discount);

            var balance = card.Balance;
            card.Balance -= amount;
            card.LastUsed = DateTimeOffset.Now;

            dbContext.DiscountHistories.Add(new CardDiscountHistory
            {
                DiscountAmount = request.Amount * (decimal)discount,
                Discount = discount,
                CardID = card.ID,
                CurrentDate = DateTimeOffset.Now
            });

            dbContext.Transactions.Add(new CardTransactionHistory
            {
                CardID = card.ID,
                Transaction = TransactionType.Fare,
                Adjustment = amount * -1,
                CreatedOn = DateTimeOffset.Now,
                ModifiedOn = DateTimeOffset.Now,
            });

            dbContext.Cards.Update(card);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new PayWithCardResult
            {
                Balance = card.Balance
            };
        }
    }

    public class PayWithCardCommand : IRequest<PayWithCardResult>
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
    }

    public class PayWithCardResult
    {
        public decimal Balance { get; set; }
    }
}