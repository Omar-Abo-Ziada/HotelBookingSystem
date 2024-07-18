using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.EF.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}