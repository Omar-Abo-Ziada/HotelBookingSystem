using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class Branch
    {
        public int ID { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        //--------------------------------------

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        //--------------------------------------

        //[ForeignKey("Hotel")]
        public int HotelID { get; set; }

        public Hotel Hotel { get; set; }
    }
}