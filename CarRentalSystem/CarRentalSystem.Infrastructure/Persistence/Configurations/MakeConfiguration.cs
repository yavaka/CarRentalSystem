using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    internal class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            //Id
            builder.HasKey(i => i.Id);

            //Name
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);
        }
    }
}
