using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class ApplicationUser : IdentityUser
    {

        //----------------------------------

        //[ForeignKey("Customer")]
        public int? CustomerID { get; set; }

        public Customer? Customer { get; set; }
    }
}