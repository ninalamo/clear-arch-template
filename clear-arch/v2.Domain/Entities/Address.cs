using Core.Domain.Common;
using System;

namespace Core.Domain.Entities
{
    public class Address : Auditable<Guid>
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}