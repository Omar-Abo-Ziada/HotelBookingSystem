using HotelBookingSystem.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.DTOs
{
    public class PostBookingDTO
    {
        //public int ID { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "CheckIn Date Must be in the future")]
        public DateTime CheckIn { get; set; } = DateTime.Now;

        [Required]
        [DateGreaterThan("CheckIn", ErrorMessage = "CheckOut Must be greater that CheckIn Date")]
        public DateTime CheckOut { get; set; } = DateTime.Now;

        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Discount { get; set; }

        //public bool IsPreviousCustomer { get; set; }

        public int customerID { get; set; }

        //---------------------------------------------

        [Required]
        [Range(1, maximum: 9 , ErrorMessage ="Rooms Must be bigger than Zero and smaller than 10")]
        public int NumberOfRooms { get; set; }

        public ICollection<PostRoomDTO> postRoomDTOs { get; set; } = new HashSet<PostRoomDTO>();

        //---------------------------------------------

        public int BranchID { get; set; }

        //public Branch Branch { get; set; }

        //---------------------------------------------

        //public ICollection<PostCustomerBookingDTO> postCustomerBookingDTOs { get; set; } = new HashSet<PostCustomerBookingDTO>();
    }
}   