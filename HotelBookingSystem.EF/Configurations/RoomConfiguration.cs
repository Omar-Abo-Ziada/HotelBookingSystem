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
                new Room { Id = 1, Type = RoomType.Single, BranchID = 1 },
                new Room { Id = 2, Type = RoomType.Single, BranchID = 1 },
                new Room { Id = 21, Type = RoomType.Double, BranchID = 1 },
                new Room { Id = 22, Type = RoomType.Double, BranchID = 1 },
                new Room { Id = 23, Type = RoomType.Suite, BranchID = 1 },

                new Room { Id = 3, Type = RoomType.Suite, BranchID = 2 },
                new Room { Id = 4, Type = RoomType.Single, BranchID = 2 },
                new Room { Id = 24, Type = RoomType.Double, BranchID = 2 },

                new Room { Id = 5, Type = RoomType.Double, BranchID = 3 },
                new Room { Id = 6, Type = RoomType.Suite, BranchID = 3 },

                new Room { Id = 7, Type = RoomType.Single, BranchID = 4 },
                new Room { Id = 8, Type = RoomType.Double, BranchID = 4 },

                new Room { Id = 9, Type = RoomType.Suite, BranchID = 5 },
                new Room { Id = 10, Type = RoomType.Single, BranchID = 5 },

                new Room { Id = 11, Type = RoomType.Double, BranchID = 6 },
                new Room { Id = 12, Type = RoomType.Suite, BranchID = 7 },

                new Room { Id = 13, Type = RoomType.Single, BranchID = 8 },
                new Room { Id = 14, Type = RoomType.Double, BranchID = 9 },

                new Room { Id = 15, Type = RoomType.Suite, BranchID = 10 },
                new Room { Id = 16, Type = RoomType.Single, BranchID = 11 },

                new Room { Id = 17, Type = RoomType.Double, BranchID = 12 },
                new Room { Id = 18, Type = RoomType.Suite, BranchID = 13 },

                new Room { Id = 19, Type = RoomType.Single, BranchID = 13 },
                new Room { Id = 20, Type = RoomType.Double, BranchID = 13 }
            );
        }
    }
}