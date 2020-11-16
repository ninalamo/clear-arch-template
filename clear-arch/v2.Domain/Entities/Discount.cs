using Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class Discount : Auditable<long>
    {
        public double Percent { get; set; }
        public string Name { get; set; }

        public static IEnumerable<Discount> GetDiscounts()
        {
            return new List<Discount>(){
                 new Discount  { Name = "X5", Percent = .20D, ID = 1 },
                 new Discount  { Name = "X4", Percent = .03D, ID =2 },
                 new Discount { Name = "X0", Percent = 0, ID = 3}
            };
        }
    }

    public class CardDiscountHistory : Auditable<Guid>
    {
        public Guid CardID { get; set; }
        public DateTimeOffset CurrentDate { get; set; }
        public double Discount { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}