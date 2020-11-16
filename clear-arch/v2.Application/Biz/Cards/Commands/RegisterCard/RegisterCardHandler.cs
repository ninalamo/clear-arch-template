using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Biz.Cards.Commands
{
    public class RegisterCardHandler : CommandHandlerBase, IRequestHandler<RegisterCardCommand, RegisterCardResult>
    {
        public RegisterCardHandler(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<RegisterCardResult> Handle(RegisterCardCommand request, CancellationToken cancellationToken)
        {
            var card = await dbContext.Cards.FirstOrDefaultAsync(i => i.CardNumber.Replace("-", "") == request.CardNumber.Replace("-", "").ToUpper());

            if (card == null) throw new NotFoundException(nameof(Card), request.CardNumber);

            if (card.CanBeRegistered())
            {
                card.IDTypeForDiscount = (IDForDiscount)request.IDForDiscount;
                card.DiscountType = CardType.Discounted;
                card.LastUsed = DateTimeOffset.Now;
                card.PWD_SeniorRef = request.PWD_SeniorRef;
            }

            dbContext.Cards.Update(card);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RegisterCardResult
            {
                Message = "",
                Success = true
            };
        }
    }

    public class RegisterCardResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class RegisterCardCommand : IRequest<RegisterCardResult>
    {
        public string CardNumber { get; set; }
        public string DocumentRef { get; set; }
        public int IDForDiscount { get; set; }
        public string PWD_SeniorRef { get; set; }
    }
}