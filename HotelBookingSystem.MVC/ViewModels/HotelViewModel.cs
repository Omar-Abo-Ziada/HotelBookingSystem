using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.MVC.ViewModels
{
    public class HotelViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        //---------------------------------------------

        //public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();

    }
}