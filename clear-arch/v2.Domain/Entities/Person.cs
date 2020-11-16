using Core.Domain.Common;
using System;

namespace Core.Domain.Entities
{
    public class Person : Auditable<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NameSuffix { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        //public Address HomeAddress { get; set; }
    }
}
