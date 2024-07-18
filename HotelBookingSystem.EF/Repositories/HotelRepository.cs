using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}