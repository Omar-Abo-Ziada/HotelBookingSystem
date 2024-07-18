using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //-------------------------------------

        //[ForeignKey("Branch")]
        public int BranchID { get; set; }

        public Branch Branch { get; set; }
    }
}