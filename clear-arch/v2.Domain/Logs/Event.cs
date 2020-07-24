using Core.Domain.Interfaces;

namespace Core.Domain.Logs
{
    public class Event : IKey<long>
    {
        public string Timestamp { get; set; }
        public string Description { get; set; }
        public string Trigger { get; set; }
        public string UserId { get; set; }
        public long ID { get; set; }
    }
}
