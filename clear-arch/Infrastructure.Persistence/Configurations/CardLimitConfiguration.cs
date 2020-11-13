using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CardLimitConfiguration : IEntityTypeConfiguration<CardLimit>
    {
        public void Configure(EntityTypeBuilder<CardLimit> builder)
        {
            builder.HasData(new[]
            {
                new CardLimit { Maximum = 10000M, Minimum = 100M, ID = 1}
            });
        }
    }
}
