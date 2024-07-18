using HotelBookingSystem.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.DTOs
{
    public class GetCustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "NationalID must be exactly 14 digits.")]
        public string NationalID { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PhoneNumber must be exactly 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PhoneNumber must be exactly 11 digits.")]
        public string PhoneNumber { get; set; }

        public AgeCategory AgeCategory { get; set; }

        public bool IsPreviousCutomer { get; set; } = false;

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public int? NumberOfRooms { get; set; }

        //-------------------------------------

        public int? RoomID { get; set; }

        //-------------------------------------

        public int BranchID { get; set; }

        //-------------------------------------
    }
}