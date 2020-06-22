using CarRentalSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(d => d.Dealer)
                .WithOne()
                .HasForeignKey<User>("DealerId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
