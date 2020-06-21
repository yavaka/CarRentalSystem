using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ValidationConstants.Options;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    internal class OptionsConfiguration : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            //Seats
            builder.Property(s => s.Seats)
                .IsRequired()
                .HasMaxLength(MaxNumberOfSeats);
        }
    }
}
