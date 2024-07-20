namespace HotelBookingSystem.Core.DTOs
{
    public class GetBookingDTO
    {
        public int ID { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        //---------------------------------------------

        //public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        //---------------------------------------------

        public int BranchID { get; set; }

        public List<int> CustomersIDs { get; set; }

        public List<int> RoomsIDs { get; set; }

        //public Branch Branch { get; set; }

        //---------------------------------------------

        //public ICollection<CustomerBooking> CustomerBookings { get; set; } = new HashSet<CustomerBooking>();
    }
}