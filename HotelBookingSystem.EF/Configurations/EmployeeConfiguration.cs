using HotelBookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.EF.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                     // Employees for Branch 1
                     new Employee { ID = 1, Name = "Employee1", BranchID = 1 },
                     new Employee { ID = 2, Name = "Employee2", BranchID = 1 },
                     new Employee { ID = 3, Name = "Employee3", BranchID = 1 },
                     new Employee { ID = 4, Name = "Employee4", BranchID = 1 },
                     new Employee { ID = 5, Name = "Employee5", BranchID = 1 },

                     // Employees for Branch 2
                     new Employee { ID = 6, Name = "Employee6", BranchID = 2 },
                     new Employee { ID = 7, Name = "Employee7", BranchID = 2 },
                     new Employee { ID = 8, Name = "Employee8", BranchID = 2 },
                     new Employee { ID = 9, Name = "Employee9", BranchID = 2 },
                     new Employee { ID = 10, Name = "Employee10", BranchID = 2 },

                     // Employees for Branch 3
                     new Employee { ID = 11, Name = "Employee11", BranchID = 3 },
                     new Employee { ID = 12, Name = "Employee12", BranchID = 3 },
                     new Employee { ID = 13, Name = "Employee13", BranchID = 3 },
                     new Employee { ID = 14, Name = "Employee14", BranchID = 3 },
                     new Employee { ID = 15, Name = "Employee15", BranchID = 3 },

                     // Employees for Branch 4
                     new Employee { ID = 16, Name = "Employee16", BranchID = 4 },
                     new Employee { ID = 17, Name = "Employee17", BranchID = 4 },
                     new Employee { ID = 18, Name = "Employee18", BranchID = 4 },
                     new Employee { ID = 19, Name = "Employee19", BranchID = 4 },
                     new Employee { ID = 20, Name = "Employee20", BranchID = 4 },

                     // Employees for Branch 5
                     new Employee { ID = 21, Name = "Employee21", BranchID = 5 },
                     new Employee { ID = 22, Name = "Employee22", BranchID = 5 },
                     new Employee { ID = 23, Name = "Employee23", BranchID = 5 },
                     new Employee { ID = 24, Name = "Employee24", BranchID = 5 },
                     new Employee { ID = 25, Name = "Employee25", BranchID = 5 },

                     // Employees for Branch 6
                     new Employee { ID = 26, Name = "Employee26", BranchID = 6 },
                     new Employee { ID = 27, Name = "Employee27", BranchID = 6 },
                     new Employee { ID = 28, Name = "Employee28", BranchID = 6 },
                     new Employee { ID = 29, Name = "Employee29", BranchID = 6 },
                     new Employee { ID = 30, Name = "Employee30", BranchID = 6 },

                     // Employees for Branch 7
                     new Employee { ID = 31, Name = "Employee31", BranchID = 7 },
                     new Employee { ID = 32, Name = "Employee32", BranchID = 7 },
                     new Employee { ID = 33, Name = "Employee33", BranchID = 7 },
                     new Employee { ID = 34, Name = "Employee34", BranchID = 7 },
                     new Employee { ID = 35, Name = "Employee35", BranchID = 7 },

                     // Employees for Branch 8
                     new Employee { ID = 36, Name = "Employee36", BranchID = 8 },
                     new Employee { ID = 37, Name = "Employee37", BranchID = 8 },
                     new Employee { ID = 38, Name = "Employee38", BranchID = 8 },
                     new Employee { ID = 39, Name = "Employee39", BranchID = 8 },
                     new Employee { ID = 40, Name = "Employee40", BranchID = 8 },

                     // Employees for Branch 9
                     new Employee { ID = 41, Name = "Employee41", BranchID = 9 },
                     new Employee { ID = 42, Name = "Employee42", BranchID = 9 },
                     new Employee { ID = 43, Name = "Employee43", BranchID = 9 },
                     new Employee { ID = 44, Name = "Employee44", BranchID = 9 },
                     new Employee { ID = 45, Name = "Employee45", BranchID = 9 },

                     // Employees for Branch 10
                     new Employee { ID = 46, Name = "Employee46", BranchID = 10 },
                     new Employee { ID = 47, Name = "Employee47", BranchID = 10 },
                     new Employee { ID = 48, Name = "Employee48", BranchID = 10 },
                     new Employee { ID = 49, Name = "Employee49", BranchID = 10 },
                     new Employee { ID = 50, Name = "Employee50", BranchID = 10 },

                     // Employees for Branch 11
                     new Employee { ID = 51, Name = "Employee51", BranchID = 11 },
                     new Employee { ID = 52, Name = "Employee52", BranchID = 11 },
                     new Employee { ID = 53, Name = "Employee53", BranchID = 11 },
                     new Employee { ID = 54, Name = "Employee54", BranchID = 11 },
                     new Employee { ID = 55, Name = "Employee55", BranchID = 11 },

                     // Employees for Branch 12
                     new Employee { ID = 56, Name = "Employee56", BranchID = 12 },
                     new Employee { ID = 57, Name = "Employee57", BranchID = 12 },
                     new Employee { ID = 58, Name = "Employee58", BranchID = 12 },
                     new Employee { ID = 59, Name = "Employee59", BranchID = 12 },
                     new Employee { ID = 60, Name = "Employee60", BranchID = 12 },

                     // Employees for Branch 13
                     new Employee { ID = 61, Name = "Employee61", BranchID = 13 },
                     new Employee { ID = 62, Name = "Employee62", BranchID = 13 },
                     new Employee { ID = 63, Name = "Employee63", BranchID = 13 },
                     new Employee { ID = 64, Name = "Employee64", BranchID = 13 },
                     new Employee { ID = 65, Name = "Employee65", BranchID = 13 },

                     // Employees for Branch 14
                     new Employee { ID = 66, Name = "Employee66", BranchID = 14 },
                     new Employee { ID = 67, Name = "Employee67", BranchID = 14 },
                     new Employee { ID = 68, Name = "Employee68", BranchID = 14 },
                     new Employee { ID = 69, Name = "Employee69", BranchID = 14 },
                     new Employee { ID = 70, Name = "Employee70", BranchID = 14 },

                     // Employees for Branch 15
                     new Employee { ID = 71, Name = "Employee71", BranchID = 15 },
                     new Employee { ID = 72, Name = "Employee72", BranchID = 15 },
                     new Employee { ID = 73, Name = "Employee73", BranchID = 15 },
                     new Employee { ID = 74, Name = "Employee74", BranchID = 15 },
                     new Employee { ID = 75, Name = "Employee75", BranchID = 15 }
                 );
        }
    }
}
