using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}