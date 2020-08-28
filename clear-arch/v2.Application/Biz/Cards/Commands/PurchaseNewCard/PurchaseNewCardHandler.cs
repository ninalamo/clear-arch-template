using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Cards.Commands
{
    public class PurchaseNewCardHandler : CommandHandlerBase, IRequestHandler<PurchaseNewCardCommand, PurchaseNewCardResult>
    {
        public PurchaseNewCardHandler(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PurchaseNewCardResult> Handle(PurchaseNewCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card
            {
                Balance = 100M,
                CardNumber = $"{new Random().Next(100,999)}{Guid.NewGuid().ToString().Split("-")[0].ToUpper()}{new Random().Next(1000, 9999)}".ToUpper(),
                DiscountType = CardType.Regular,
                IDTypeForDiscount = IDForDiscount.None,
                LastUsed = DateTimeOffset.Now,
            };
            dbContext.Cards.Add(card);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new PurchaseNewCardResult
            {
                CardNumber = card.CardNumber,
                Balance = card.Balance,
                CardType = card.DiscountType.ToString(),
                ID = card.ID
            };
        }
    }

    public class PurchaseNewCardResult
    {
        public string CardNumber { get; set; }
        public Guid ID { get; set; }
        public decimal Balance { get; set; }
        public string CardType { get; set; }
    }

    public class PurchaseNewCardCommand : IRequest<PurchaseNewCardResult>
    {
    }
}