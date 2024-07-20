using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.EF
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Bed> Beds { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerBooking> CustomerBookings { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Hotel> Hotels { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///By default, EF Core uses TPH inheritance where all classes in the hierarchy are stored in a single table. 
            ///So To solve this and make the cutomer Type has his own table => Use Table-per-Type (TPT) Inheritance:
            ///configuring the Customer entity to be mapped to a separate table. EF Core 5.0 and later supports TPT.
            //modelBuilder.Entity<Customer>()
            //         .ToTable("Customers");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        ///<summary>
        ///Enforce Validation on RunTime Before Sending Changes to DB 
        ///  This method will enforce validation on all entities, 
        ///  regardless of how they are added or modified, 
        ///  including those configured via Fluent API.
        /// </summary>
        public override int SaveChanges()
        {

            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified ||
                           e.State == EntityState.Added //&&( e.Entity is Employee)  => can use certain conditions also if needed
                           select e.Entity;

            bool IsValid = true;
            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
                IsValid = Validator.TryValidateObject(Entity, validationContext, new List<ValidationResult>());
                //true: This parameter specifies whether to validate all properties (when true) or only required properties (when false). >> in case of using validate object()
            }
            if (IsValid)
            {
                return base.SaveChanges();
            }
            return 0;  // indication for 0 entries added or updated >> saving didnot happen due to validation errors >> when call savechanges() check return != 0

        }
    }
}