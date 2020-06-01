using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain.Common;
using Core.Domain.ValueObjects;

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
