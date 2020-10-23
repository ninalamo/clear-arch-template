using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Position : Auditable<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}