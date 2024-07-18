namespace HotelBookingSystem.Core.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //---------------------------------------------

        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }
}