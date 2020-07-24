using Core.Common;
using System;

namespace Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTimeOffset Now => DateTimeOffset.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
