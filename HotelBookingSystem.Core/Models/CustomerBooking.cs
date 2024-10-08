﻿namespace HotelBookingSystem.Core.Models
{
    public class CustomerBooking
    {

        //------------------------------------------

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        //------------------------------------------

        public int BookingID { get; set; }

        public Booking Booking { get; set; }
    }
}