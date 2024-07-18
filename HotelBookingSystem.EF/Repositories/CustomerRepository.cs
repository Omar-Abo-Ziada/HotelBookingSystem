using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}