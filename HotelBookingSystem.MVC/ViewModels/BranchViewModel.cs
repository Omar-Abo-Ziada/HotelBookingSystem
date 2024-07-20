namespace HotelBookingSystem.MVC.ViewModels
{
    public class BranchViewModel
    {
        public int ID { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        //--------------------------------------

        public int HotelID { get; set; }
    }
}