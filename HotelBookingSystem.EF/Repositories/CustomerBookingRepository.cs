using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class CustomerBookingRepository : GenericRepository<CustomerBooking>, ICustomerBookingRepository
    {
        public CustomerBookingRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}