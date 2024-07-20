using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            // Initial Testing data for Hotels
            builder.HasData(
                new Hotel { ID = 1, Name = "Hotel A" },
                new Hotel { ID = 2, Name = "Hotel B" },
                new Hotel { ID = 3, Name = "Hotel C" },
                new Hotel { ID = 4, Name = "Hotel D" },
                new Hotel { ID = 5, Name = "Hotel E" }
            );
        }
    }
}