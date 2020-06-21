using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            //Id
            builder.HasKey(i =>i.Id);

            //Name
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            //PhoneNumber
            builder.OwnsOne(p => p.PhoneNumber, pn => 
            {
                //Dealer is the owner
                pn.WithOwner();

                pn.Property(ph => ph.Number);
            });

            //CarAds
            builder.HasMany(c => c.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_carAds");
        }
    }
}
