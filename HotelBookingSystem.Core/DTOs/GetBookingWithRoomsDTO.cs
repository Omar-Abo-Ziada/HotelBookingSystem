using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.DTOs
{
    public class GetBookingWithRoomsDTO
    {
        public int ID { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        public bool IsPreviousCustomer { get; set; }

        //---------------------------------------------

        public ICollection<GetRoomDTO> Rooms { get; set; } = new HashSet<GetRoomDTO>();

        //---------------------------------------------

        public int BranchID { get; set; }

        //public Branch Branch { get; set; }

        //---------------------------------------------

        public int CustomerID { get; set; }

        //public ICollection<CustomerBooking> CustomerBookings { get; set; } = new HashSet<CustomerBooking>();
    }
}