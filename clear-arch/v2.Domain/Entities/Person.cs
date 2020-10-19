using Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class Person : Auditable<Guid>
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NameSuffix { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}