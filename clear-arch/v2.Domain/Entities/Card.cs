using Core.Domain.Common;
using Core.Domain.Interfaces;
using System;

namespace Core.Domain.Entities
{
    public class Card : Auditable<Guid>
    {
        public string CardNumber { get; set; }
        public DateTimeOffset LastUsed { get; set; }
        public decimal Balance { get; set; }
        public CardType DiscountType { get; set; }
        public string PWD_SeniorRef { get; set; }
        public IDForDiscount IDTypeForDiscount { get; set; }

        public bool CanBeRegistered()
        {
            var date = CreatedOn.AddMonths(6);
            return DateTimeOffset.Now.Date <= date.Date;
        }

        public bool IsValid => LastUsed.AddYears(5).Date >= DateTimeOffset.Now.Date;
    }



}