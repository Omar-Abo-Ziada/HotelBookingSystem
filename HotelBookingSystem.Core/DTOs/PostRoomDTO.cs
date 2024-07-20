using HotelBookingSystem.Core.Enums;
using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.Core.DTOs
{
    public class PostRoomDTO
    {
        //public int Id { get; set; }

        public RoomType Type { get; set; }

        //public int NumberOfBeds { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfChilds { get; set; }

        //-------------------------------------

        //public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        //-------------------------------------

        //public ICollection<Bed> Beds { get; set; } = new HashSet<Bed>();

        //-------------------------------------

        //public int BranchID { get; set; }

        //public Branch Branch { get; set; }

        //-------------------------------------

        //public int? BookingID { get; set; }

        //public Booking? Booking { get; set; }
    }
}