using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IKey<T> where T : struct, IEquatable<T>, IComparable<T>
    {
        T ID { get; set; }
    }
}
