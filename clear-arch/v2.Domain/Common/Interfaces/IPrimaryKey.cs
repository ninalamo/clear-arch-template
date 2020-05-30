using System;

namespace Core.Domain.Common.Interfaces
{
    public interface IPrimaryKey<T>  where T : struct, IEquatable<T>, IComparable<T>
    {
        T ID { get; set; }
    }
}
