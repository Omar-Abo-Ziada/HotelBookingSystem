using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    internal class BedRepository : GenericRepository<Bed>, IBedRepository
    {
        public BedRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}