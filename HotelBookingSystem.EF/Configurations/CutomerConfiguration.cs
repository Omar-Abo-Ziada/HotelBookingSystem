using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class CutomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
        //    builder.HasData(
        //    new Customer { NID = "1234567890", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(1), NumberOfRooms = 1, RoomID = 1 },
        //    new Customer { NID = "0987654321", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(2), NumberOfRooms = 2, RoomID = 2 },
        //    new Customer { NID = "1122334455", AgeCategory = AgeCategory.Child, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(3), NumberOfRooms = 3, RoomID = 3 },
        //    new Customer { NID = "6677889900", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(4), NumberOfRooms = 4, RoomID = 4 },
        //    new Customer { NID = "9988776655", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(5), NumberOfRooms = 5, RoomID = 5 },
        //    new Customer { NID = "5544332211", AgeCategory = AgeCategory.Child, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(6), NumberOfRooms = 6, RoomID = 6 },
        //    new Customer { NID = "4433221100", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(7), NumberOfRooms = 7, RoomID = 7 },
        //    new Customer { NID = "1234432100", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(8), NumberOfRooms = 8, RoomID = 8 },
        //    new Customer { NID = "5678901234", AgeCategory = AgeCategory.Child, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(9), NumberOfRooms = 9, RoomID = 9 },
        //    new Customer {  NID = "0987651234", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(10), NumberOfRooms = 10, RoomID = 10 },
        //    new Customer {  NID = "2345678901", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(11), NumberOfRooms = 11, RoomID = 11 },
        //    new Customer {  NID = "3456789012", AgeCategory = AgeCategory.Child, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(12), NumberOfRooms = 12, RoomID = 12 },
        //    new Customer {  NID = "4567890123", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(13), NumberOfRooms = 13, RoomID = 13 },
        //    new Customer {  NID = "5678901234", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(14), NumberOfRooms = 14, RoomID = 14 },
        //    new Customer {  NID = "6789012345", AgeCategory = AgeCategory.Child, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(15), NumberOfRooms = 15, RoomID = 15 },
        //    new Customer {  NID = "7890123456", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(16), NumberOfRooms = 16, RoomID = 16 },
        //    new Customer {  NID = "8901234567", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(17), NumberOfRooms = 17, RoomID = 17 },
        //    new Customer {  NID = "9012345678", AgeCategory = AgeCategory.Child, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(18), NumberOfRooms = 18, RoomID = 18 },
        //    new Customer {  NID = "0123456789", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = false, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(19), NumberOfRooms = 19, RoomID = 19 },
        //    new Customer {  NID = "1234567891", AgeCategory = AgeCategory.Adult, IsPreviousCutomer = true, CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(20), NumberOfRooms = 20, RoomID = 20 }
        //);

        }
    }
}