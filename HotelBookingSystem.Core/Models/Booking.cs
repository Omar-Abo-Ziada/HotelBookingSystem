using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Core.Models
{
    public class Booking
    {
        public int ID { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        public Branch Branch { get; set; }
    }
}