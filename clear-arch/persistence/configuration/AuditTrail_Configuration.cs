using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistence.configuration
{
    public class AuditTrail_Configuration : IEntityTypeConfiguration<AuditTrail>
    {
       
        public void Configure(EntityTypeBuilder<AuditTrail> builder)
        {
            builder.HasNoKey();
        }
    }
}
