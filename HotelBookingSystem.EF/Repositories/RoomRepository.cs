using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}