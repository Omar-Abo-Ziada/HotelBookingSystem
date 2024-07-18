using HotelBookingSystem.Core.Enums;
using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room { Id = 1, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 1 },
                new Room { Id = 2, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 1 },
                new Room { Id = 3, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 2 },
                new Room { Id = 4, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 2 },
                new Room { Id = 5, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 3 },
                new Room { Id = 6, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 3 },
                new Room { Id = 7, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 1 },
                new Room { Id = 8, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 1 },
                new Room { Id = 9, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 2 },
                new Room { Id = 10, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 2 },
                new Room { Id = 11, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 3 },
                new Room { Id = 12, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 3 },
                new Room { Id = 13, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 1 },
                new Room { Id = 14, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 1 },
                new Room { Id = 15, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 2 },
                new Room { Id = 16, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 2 },
                new Room { Id = 17, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 3 },
                new Room { Id = 18, Type = RoomType.Suite, NumberOfBeds = 3, BranchID = 3 },
                new Room { Id = 19, Type = RoomType.Single, NumberOfBeds = 1, BranchID = 1 },
                new Room { Id = 20, Type = RoomType.Double, NumberOfBeds = 2, BranchID = 1 }
            );
        }
    }
}