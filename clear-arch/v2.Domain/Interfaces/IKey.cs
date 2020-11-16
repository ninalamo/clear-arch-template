using System;

namespace Core.Domain.Interfaces
{
    public interface IKey<T> where T : struct, IEquatable<T>, IComparable<T>
    {
        T ID { get; set; }
    }
}
