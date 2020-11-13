using Core.Domain.Common;
using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class BaseFare : Auditable<int>
    {
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }

        public static IEnumerable<BaseFare> Fares => new List<BaseFare>() { 
            new BaseFare { Amount = 11.00M, IsActive = true, ID = 1 } 
        };
    }
}