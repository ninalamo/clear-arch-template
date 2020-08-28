using Core.Domain.Common;
using Core.Domain.Interfaces;
using System;

namespace Core.Domain.Entities
{
    public class CardTransactionHistory : Auditable<Guid>
    {
        public Guid CardID { get; set; }
        public decimal Adjustment { get; set; }
        public Card Card { get; set; }
        public TransactionType Transaction { get; set; }
    }
}