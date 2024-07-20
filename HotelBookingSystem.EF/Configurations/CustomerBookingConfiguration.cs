using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class CustomerBookingConfiguration : IEntityTypeConfiguration<CustomerBooking>
    {
        public void Configure(EntityTypeBuilder<CustomerBooking> builder)
        {
            builder.HasKey(cb => new { cb.CustomerID, cb.BookingID });

            builder.HasOne(cb => cb.Customer).WithMany(c => c.CustomerBookings);

            builder.HasOne(cb => cb.Booking).WithMany(b => b.CustomerBookings);
        }
    }
}