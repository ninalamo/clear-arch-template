using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class CardLimit : Auditable<int>
    {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
    }
}
