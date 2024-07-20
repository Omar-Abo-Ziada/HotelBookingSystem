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

                new Room { Id = 3, Type = RoomType.Single, BranchID = 2 },
                new Room { Id = 4, Type = RoomType.Single, BranchID = 2 },
                new Room { Id = 24, Type = RoomType.Double, BranchID = 2 },
                new Room { Id = 25, Type = RoomType.Double, BranchID = 2 },
                new Room { Id = 26, Type = RoomType.Suite, BranchID = 2 },

                new Room { Id = 5, Type = RoomType.Single, BranchID = 3 },
                new Room { Id = 6, Type = RoomType.Single, BranchID = 3 },
                new Room { Id = 27, Type = RoomType.Double, BranchID = 3 },
                new Room { Id = 75, Type = RoomType.Double, BranchID = 3 },
                new Room { Id = 28, Type = RoomType.Suite, BranchID = 3 },

                new Room { Id = 7, Type = RoomType.Single, BranchID = 4 },
                new Room { Id = 29, Type = RoomType.Single, BranchID = 4 },
                new Room { Id = 8, Type = RoomType.Double, BranchID = 4 },
                new Room { Id = 30, Type = RoomType.Double, BranchID = 4 },
                new Room { Id = 31, Type = RoomType.Suite, BranchID = 4 },

                new Room { Id = 9, Type = RoomType.Suite, BranchID = 5 },
                new Room { Id = 10, Type = RoomType.Single, BranchID = 5 },
                new Room { Id = 32, Type = RoomType.Single, BranchID = 5 },
                new Room { Id = 33, Type = RoomType.Double, BranchID = 5 },
                new Room { Id = 34, Type = RoomType.Double, BranchID = 5 },

                new Room { Id = 11, Type = RoomType.Double, BranchID = 6 },
                new Room { Id = 12, Type = RoomType.Suite, BranchID = 6 },
                new Room { Id = 35, Type = RoomType.Double, BranchID = 6 },
                new Room { Id = 36, Type = RoomType.Single, BranchID = 6 },
                new Room { Id = 37, Type = RoomType.Single, BranchID = 6 },

                new Room { Id = 13, Type = RoomType.Single, BranchID = 7 },
                new Room { Id = 14, Type = RoomType.Double, BranchID = 7 },
                new Room { Id = 38, Type = RoomType.Double, BranchID = 7 },
                new Room { Id = 39, Type = RoomType.Single, BranchID = 7 },
                new Room { Id = 40, Type = RoomType.Suite, BranchID = 7 },

                new Room { Id = 15, Type = RoomType.Suite, BranchID = 8 },
                new Room { Id = 16, Type = RoomType.Single, BranchID = 8 },
                new Room { Id = 41, Type = RoomType.Single, BranchID = 8 },
                new Room { Id = 42, Type = RoomType.Double, BranchID = 8 },
                new Room { Id = 43, Type = RoomType.Double, BranchID = 8 },

                new Room { Id = 17, Type = RoomType.Double, BranchID = 9 },
                new Room { Id = 18, Type = RoomType.Suite, BranchID = 9 },
                new Room { Id = 44, Type = RoomType.Double, BranchID = 9 },
                new Room { Id = 45, Type = RoomType.Single, BranchID = 9 },
                new Room { Id = 46, Type = RoomType.Single, BranchID = 9 },

                new Room { Id = 19, Type = RoomType.Single, BranchID = 10 },
                new Room { Id = 20, Type = RoomType.Double, BranchID = 10 },
                new Room { Id = 47, Type = RoomType.Single, BranchID = 10 },
                new Room { Id = 48, Type = RoomType.Double, BranchID = 10 },
                new Room { Id = 49, Type = RoomType.Suite, BranchID = 10 },

                new Room { Id = 50, Type = RoomType.Double, BranchID = 11 },
                new Room { Id = 51, Type = RoomType.Suite, BranchID = 11 },
                new Room { Id = 52, Type = RoomType.Double, BranchID = 11 },
                new Room { Id = 53, Type = RoomType.Single, BranchID = 11 },
                new Room { Id = 54, Type = RoomType.Single, BranchID = 11 },


                new Room { Id = 55, Type = RoomType.Double, BranchID = 12 },
                new Room { Id = 56, Type = RoomType.Suite, BranchID = 12 },
                new Room { Id = 57, Type = RoomType.Double, BranchID = 12 },
                new Room { Id = 58, Type = RoomType.Single, BranchID = 12 },
                new Room { Id = 59, Type = RoomType.Single, BranchID = 12 },


                new Room { Id = 60, Type = RoomType.Double, BranchID = 13 },
                new Room { Id = 61, Type = RoomType.Suite, BranchID = 13 },
                new Room { Id = 62, Type = RoomType.Double, BranchID = 13 },
                new Room { Id = 63, Type = RoomType.Single, BranchID = 13 },
                new Room { Id = 64, Type = RoomType.Single, BranchID = 13 },


                new Room { Id = 65, Type = RoomType.Double, BranchID = 14 },
                new Room { Id = 66, Type = RoomType.Suite, BranchID = 14 },
                new Room { Id = 67, Type = RoomType.Double, BranchID = 14 },
                new Room { Id = 68, Type = RoomType.Single, BranchID = 14 },
                new Room { Id = 69, Type = RoomType.Single, BranchID = 14 },


                new Room { Id = 70, Type = RoomType.Double, BranchID = 15 },
                new Room { Id = 71, Type = RoomType.Suite, BranchID = 15 },
                new Room { Id = 72, Type = RoomType.Double, BranchID = 15 },
                new Room { Id = 73, Type = RoomType.Single, BranchID = 15 },
                new Room { Id = 74, Type = RoomType.Single, BranchID = 15 }

            );
        }
    }
}