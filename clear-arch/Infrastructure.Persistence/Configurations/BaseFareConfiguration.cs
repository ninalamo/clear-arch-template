using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BaseFareConfiguration : IEntityTypeConfiguration<BaseFare>
    {
        public void Configure(EntityTypeBuilder<BaseFare> builder)
        {
            builder.HasData(BaseFare.Fares);
        }
    }
}
