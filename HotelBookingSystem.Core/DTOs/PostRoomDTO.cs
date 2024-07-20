using HotelBookingSystem.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.DTOs
{
    public class PostRoomDTO
    {
        //public int Id { get; set; }

        [Required]
        public RoomType Type { get; set; }

        //public int NumberOfBeds { get; set; }
        [Required]
        [Range(0 , maximum:10, ErrorMessage ="Must be from Zero to 10")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Range(0, maximum: 10, ErrorMessage = "Must be from Zero to 10")]
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