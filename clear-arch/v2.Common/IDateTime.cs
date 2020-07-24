using System;

namespace Core.Common
{
    public interface IDateTime
    {
        DateTimeOffset Now { get; }
    }
}
