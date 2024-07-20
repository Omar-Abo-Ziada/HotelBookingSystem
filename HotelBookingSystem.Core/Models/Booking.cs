using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class Booking
    {
        public int ID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        public bool IsPreviousCustomer { get; set; } 

        //---------------------------------------------

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        //---------------------------------------------

        public int BranchID { get; set; }

        public Branch Branch { get; set; }

        //---------------------------------------------

        public ICollection<CustomerBooking> CustomerBookings { get; set; } = new HashSet<CustomerBooking>();
    }
}