using Core.Domain.Common;
using System;

namespace Core.Domain.Entities
{
    public class Email : Auditable<Guid>
    {
        public string Title { get; set;  }
        public bool? IsPrimary { get; set; }
    }
}