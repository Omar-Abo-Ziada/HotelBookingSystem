using HotelBookingSystem.Core.Models;

namespace HotelBookingSystem.Core.DTOs
{
    public class GetBranchDTO
    {
        public int ID { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        //--------------------------------------

        //public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        //public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        //public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        //--------------------------------------

        public int HotelID { get; set; }

        //public Hotel Hotel { get; set; }
    }
}
