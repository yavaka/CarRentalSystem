using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ValidationConstants.CarAd;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    internal class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
        {
            //Id
            builder.HasKey(i => i.Id);

            //Make
            builder.HasOne(m => m.Make)
                .WithMany()
                .HasForeignKey("MakeId")
                .OnDelete(DeleteBehavior.Restrict);

            //Model
            builder.Property(m => m.Model)
                .IsRequired()
                .HasMaxLength(MaxModelLength);

            //Category
            builder.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            //ImageUrl
            builder.Property(img => img.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            //PricePerDay
            builder.Property(p => p.PricePerDay)
                .IsRequired();

            //IsAvailable
            builder.Property(a => a.IsAvailable)
                .IsRequired();

            //Options
            builder.OwnsOne(opt => opt.Options, o =>
            {
                //CarAd entity is the owner
                o.WithOwner();

                o.Property(op => op.Seats);
                o.Property(op => op.HasClimateControl);

                o.OwnsOne(op => op.TransmissionType, t =>
                {
                    //Options value object is the owner
                    t.WithOwner();

                    t.Property(tr => tr.Value);
                });
            });

        }
    }
}
