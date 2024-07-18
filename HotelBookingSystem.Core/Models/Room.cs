using HotelBookingSystem.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class Room
    {
        public int Id { get; set; }

        public  RoomType Type { get; set; }

        public int NumberOfBeds { get; set; }

        //-------------------------------------

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        //-------------------------------------

        public ICollection<Bed> Beds { get; set; } = new HashSet<Bed>();

        //-------------------------------------

        public int BranchID { get; set; }

        public Branch Branch { get; set; }
    }
}