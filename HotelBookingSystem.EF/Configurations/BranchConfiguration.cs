using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.EF.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            // Initial data for Branches
            builder.HasData(
                // Branches for Hotel A
                new Branch { ID = 1, Country = "Country1", State = "State1", City = "City1", Street = "Street1", PostalCode = "12345", HotelID = 1 },
                new Branch { ID = 2, Country = "Country1", State = "State1", City = "City2", Street = "Street2", PostalCode = "12346", HotelID = 1 },
                new Branch { ID = 3, Country = "Country1", State = "State1", City = "City3", Street = "Street3", PostalCode = "12347", HotelID = 1 },

                // Branches for Hotel B
                new Branch { ID = 4, Country = "Country2", State = "State2", City = "City1", Street = "Street4", PostalCode = "22345", HotelID = 2 },
                new Branch { ID = 5, Country = "Country2", State = "State2", City = "City2", Street = "Street5", PostalCode = "22346", HotelID = 2 },
                new Branch { ID = 6, Country = "Country2", State = "State2", City = "City3", Street = "Street6", PostalCode = "22347", HotelID = 2 },

                // Branches for Hotel C
                new Branch { ID = 7, Country = "Country3", State = "State3", City = "City1", Street = "Street7", PostalCode = "32345", HotelID = 3 },
                new Branch { ID = 8, Country = "Country3", State = "State3", City = "City2", Street = "Street8", PostalCode = "32346", HotelID = 3 },
                new Branch { ID = 9, Country = "Country3", State = "State3", City = "City3", Street = "Street9", PostalCode = "32347", HotelID = 3 },

                // Branches for Hotel D
                new Branch { ID = 10, Country = "Country4", State = "State4", City = "City1", Street = "Street10", PostalCode = "42345", HotelID = 4 },
                new Branch { ID = 11, Country = "Country4", State = "State4", City = "City2", Street = "Street11", PostalCode = "42346", HotelID = 4 },
                new Branch { ID = 12, Country = "Country4", State = "State4", City = "City3", Street = "Street12", PostalCode = "42347", HotelID = 4 },

                // Branches for Hotel E
                new Branch { ID = 13, Country = "Country5", State = "State5", City = "City1", Street = "Street13", PostalCode = "52345", HotelID = 5 },
                new Branch { ID = 14, Country = "Country5", State = "State5", City = "City2", Street = "Street14", PostalCode = "52346", HotelID = 5 },
                new Branch { ID = 15, Country = "Country5", State = "State5", City = "City3", Street = "Street15", PostalCode = "52347", HotelID = 5 }
            );
        }
    }
}
