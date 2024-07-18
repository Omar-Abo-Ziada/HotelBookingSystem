using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class BedConfiguration : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {
            builder.HasData(
               // Room 1: 1 Bed
               new Bed { ID = 1, RoomID = 1 },

               // Room 2: 2 Beds
               new Bed { ID = 2, RoomID = 2 },
               new Bed { ID = 3, RoomID = 2 },

               // Room 3: 3 Beds
               new Bed { ID = 4, RoomID = 3 },
               new Bed { ID = 5, RoomID = 3 },
               new Bed { ID = 6, RoomID = 3 },

               // Room 4: 1 Bed
               new Bed { ID = 7, RoomID = 4 },

               // Room 5: 2 Beds
               new Bed { ID = 8, RoomID = 5 },
               new Bed { ID = 9, RoomID = 5 },

               // Room 6: 3 Beds
               new Bed { ID = 10, RoomID = 6 },
               new Bed { ID = 11, RoomID = 6 },
               new Bed { ID = 12, RoomID = 6 },

               // Room 7: 1 Bed
               new Bed { ID = 13, RoomID = 7 },

               // Room 8: 2 Beds
               new Bed { ID = 14, RoomID = 8 },
               new Bed { ID = 15, RoomID = 8 },

               // Room 9: 3 Beds
               new Bed { ID = 16, RoomID = 9 },
               new Bed { ID = 17, RoomID = 9 },
               new Bed { ID = 18, RoomID = 9 },

               // Room 10: 1 Bed
               new Bed { ID = 19, RoomID = 10 },

               // Room 11: 2 Beds
               new Bed { ID = 20, RoomID = 11 },
               new Bed { ID = 21, RoomID = 11 },

               // Room 12: 3 Beds
               new Bed { ID = 22, RoomID = 12 },
               new Bed { ID = 23, RoomID = 12 },
               new Bed { ID = 24, RoomID = 12 },

               // Room 13: 1 Bed
               new Bed { ID = 25, RoomID = 13 },

               // Room 14: 2 Beds
               new Bed { ID = 26, RoomID = 14 },
               new Bed { ID = 27, RoomID = 14 },

               // Room 15: 3 Beds
               new Bed { ID = 28, RoomID = 15 },
               new Bed { ID = 29, RoomID = 15 },
               new Bed { ID = 30, RoomID = 15 },

               // Room 16: 1 Bed
               new Bed { ID = 31, RoomID = 16 },

               // Room 17: 2 Beds
               new Bed { ID = 32, RoomID = 17 },
               new Bed { ID = 33, RoomID = 17 },

               // Room 18: 3 Beds
               new Bed { ID = 34, RoomID = 18 },
               new Bed { ID = 35, RoomID = 18 },
               new Bed { ID = 36, RoomID = 18 },

               // Room 19: 1 Bed
               new Bed { ID = 37, RoomID = 19 },

               // Room 20: 2 Beds
               new Bed { ID = 38, RoomID = 20 },
               new Bed { ID = 39, RoomID = 20 }
           );
        }
    }
}