namespace HotelBookingSystem.Core.DTOs
{
    public class PostBookingDTO
    {
        //public int ID { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Discount { get; set; }

        //public bool IsPreviousCustomer { get; set; }

        public int customerID { get; set; }

        //---------------------------------------------

        public int NumberOfRooms { get; set; }

        public ICollection<PostRoomDTO> postRoomDTOs { get; set; } = new HashSet<PostRoomDTO>();

        //---------------------------------------------

        public int BranchID { get; set; }

        //public Branch Branch { get; set; }

        //---------------------------------------------

        //public ICollection<PostCustomerBookingDTO> postCustomerBookingDTOs { get; set; } = new HashSet<PostCustomerBookingDTO>();
    }
}   