using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.EF.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            // Initial data for Hotel
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