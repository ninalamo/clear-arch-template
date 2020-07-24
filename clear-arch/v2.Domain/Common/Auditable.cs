using Core.Domain.Interfaces;
using System;

namespace Core.Domain.Common
{
    public abstract class Auditable<T> : IAuditable, IKey<T> where T : struct, IEquatable<T>, IComparable<T>
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public T ID { get; set; }
    }
}