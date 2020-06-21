using CarRentalSystem.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CarRentalSystem.Domain.Models.ValidationConstants.Category;
using static CarRentalSystem.Domain.Models.ValidationConstants.Common;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Id
            builder.HasKey(i => i.Id);

            //Name
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            //Description
            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
