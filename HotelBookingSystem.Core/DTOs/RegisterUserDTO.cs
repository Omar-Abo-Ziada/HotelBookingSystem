using HotelBookingSystem.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "NationalID must be exactly 14 digits.")]
        public string NationalID { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PhoneNumber must be exactly 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PhoneNumber must be exactly 11 digits.")]
        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public AgeCategory AgeCategory { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        [Required, StringLength(256)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string RepeatPassword { get; set; }

        //public bool IsPreviousCutomer { get; set; } = false;

        //public DateTime? CheckIn { get; set; }

        //public DateTime? CheckOut { get; set; }

        //public int? NumberOfRooms { get; set; }

        //-------------------------------------

        //public int? RoomID { get; set; }

        //public Room? Room { get; set; }

        //-------------------------------------

        //public int? BranchID { get; set; }

        //public Branch? Branch { get; set; }

        //-------------------------------------

        //[ForeignKey("ApplicationUser")]
        //public string ApplicationUserID { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}