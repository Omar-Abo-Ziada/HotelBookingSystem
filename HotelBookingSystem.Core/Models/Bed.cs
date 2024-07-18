using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Core.Models
{
    public class Bed
    {
        public int ID { get; set; }

        //--------------------------------

        //[ForeignKey("Room")]
        public int RoomID { get; set; }

        public Room Room { get; set; }
    }
}