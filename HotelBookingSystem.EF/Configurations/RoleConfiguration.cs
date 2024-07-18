using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Seed roles
            builder.HasData(
                new IdentityRole { Id = "1", Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "ADMIN" }
            );
        }
    }
}