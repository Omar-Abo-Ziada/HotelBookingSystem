namespace HotelBookingSystem.MVC.Models
{
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expired { get; set; } 
    }
}