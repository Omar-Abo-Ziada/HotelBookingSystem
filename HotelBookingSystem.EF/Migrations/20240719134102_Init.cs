using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystem.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AgeCategory = table.Column<int>(type: "int", nullable: false),
                    IsPreviousCustomer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPreviousCustomer = table.Column<bool>(type: "bit", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBookings",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBookings", x => new { x.CustomerID, x.BookingID });
                    table.ForeignKey(
                        name: "FK_CustomerBookings_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerBookings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChilds = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rooms_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "fe0f81c0-e65e-4f06-93db-f4ebfd47b80e", "Customer", "CUSTOMER" },
                    { "2", "5672a166-aea2-4a29-a728-8703ab29576e", "Employee", "EMPLOYEE" },
                    { "3", "807771d3-8839-4af2-a750-688331a5a5e2", "Admin", "ADMIN" },
                    { "4", "24b4a14e-0dd9-4265-af23-b233bc35ac18", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Hotel A" },
                    { 2, "Hotel B" },
                    { 3, "Hotel C" },
                    { 4, "Hotel D" },
                    { 5, "Hotel E" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "City", "Country", "HotelID", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "City1", "Country1", 1, "12345", "State1", "Street1" },
                    { 2, "City2", "Country1", 1, "12346", "State1", "Street2" },
                    { 3, "City3", "Country1", 1, "12347", "State1", "Street3" },
                    { 4, "City1", "Country2", 2, "22345", "State2", "Street4" },
                    { 5, "City2", "Country2", 2, "22346", "State2", "Street5" },
                    { 6, "City3", "Country2", 2, "22347", "State2", "Street6" },
                    { 7, "City1", "Country3", 3, "32345", "State3", "Street7" },
                    { 8, "City2", "Country3", 3, "32346", "State3", "Street8" },
                    { 9, "City3", "Country3", 3, "32347", "State3", "Street9" },
                    { 10, "City1", "Country4", 4, "42345", "State4", "Street10" },
                    { 11, "City2", "Country4", 4, "42346", "State4", "Street11" },
                    { 12, "City3", "Country4", 4, "42347", "State4", "Street12" },
                    { 13, "City1", "Country5", 5, "52345", "State5", "Street13" },
                    { 14, "City2", "Country5", 5, "52346", "State5", "Street14" },
                    { 15, "City3", "Country5", 5, "52347", "State5", "Street15" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "BranchID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Employee1" },
                    { 2, 1, "Employee2" },
                    { 3, 1, "Employee3" },
                    { 4, 1, "Employee4" },
                    { 5, 1, "Employee5" },
                    { 6, 2, "Employee6" },
                    { 7, 2, "Employee7" },
                    { 8, 2, "Employee8" },
                    { 9, 2, "Employee9" },
                    { 10, 2, "Employee10" },
                    { 11, 3, "Employee11" },
                    { 12, 3, "Employee12" },
                    { 13, 3, "Employee13" },
                    { 14, 3, "Employee14" },
                    { 15, 3, "Employee15" },
                    { 16, 4, "Employee16" },
                    { 17, 4, "Employee17" },
                    { 18, 4, "Employee18" },
                    { 19, 4, "Employee19" },
                    { 20, 4, "Employee20" },
                    { 21, 5, "Employee21" },
                    { 22, 5, "Employee22" },
                    { 23, 5, "Employee23" },
                    { 24, 5, "Employee24" },
                    { 25, 5, "Employee25" },
                    { 26, 6, "Employee26" },
                    { 27, 6, "Employee27" },
                    { 28, 6, "Employee28" },
                    { 29, 6, "Employee29" },
                    { 30, 6, "Employee30" },
                    { 31, 7, "Employee31" },
                    { 32, 7, "Employee32" },
                    { 33, 7, "Employee33" },
                    { 34, 7, "Employee34" },
                    { 35, 7, "Employee35" },
                    { 36, 8, "Employee36" },
                    { 37, 8, "Employee37" },
                    { 38, 8, "Employee38" },
                    { 39, 8, "Employee39" },
                    { 40, 8, "Employee40" },
                    { 41, 9, "Employee41" },
                    { 42, 9, "Employee42" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "BranchID", "Name" },
                values: new object[,]
                {
                    { 43, 9, "Employee43" },
                    { 44, 9, "Employee44" },
                    { 45, 9, "Employee45" },
                    { 46, 10, "Employee46" },
                    { 47, 10, "Employee47" },
                    { 48, 10, "Employee48" },
                    { 49, 10, "Employee49" },
                    { 50, 10, "Employee50" },
                    { 51, 11, "Employee51" },
                    { 52, 11, "Employee52" },
                    { 53, 11, "Employee53" },
                    { 54, 11, "Employee54" },
                    { 55, 11, "Employee55" },
                    { 56, 12, "Employee56" },
                    { 57, 12, "Employee57" },
                    { 58, 12, "Employee58" },
                    { 59, 12, "Employee59" },
                    { 60, 12, "Employee60" },
                    { 61, 13, "Employee61" },
                    { 62, 13, "Employee62" },
                    { 63, 13, "Employee63" },
                    { 64, 13, "Employee64" },
                    { 65, 13, "Employee65" },
                    { 66, 14, "Employee66" },
                    { 67, 14, "Employee67" },
                    { 68, 14, "Employee68" },
                    { 69, 14, "Employee69" },
                    { 70, 14, "Employee70" },
                    { 71, 15, "Employee71" },
                    { 72, 15, "Employee72" },
                    { 73, 15, "Employee73" },
                    { 74, 15, "Employee74" },
                    { 75, 15, "Employee75" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BookingID", "BranchID", "NumberOfAdults", "NumberOfChilds", "Type" },
                values: new object[,]
                {
                    { 1, null, 1, 0, 0, 0 },
                    { 2, null, 1, 0, 0, 0 },
                    { 3, null, 2, 0, 0, 2 },
                    { 4, null, 2, 0, 0, 0 },
                    { 5, null, 3, 0, 0, 1 },
                    { 6, null, 3, 0, 0, 2 },
                    { 7, null, 4, 0, 0, 0 },
                    { 8, null, 4, 0, 0, 1 },
                    { 9, null, 5, 0, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BookingID", "BranchID", "NumberOfAdults", "NumberOfChilds", "Type" },
                values: new object[,]
                {
                    { 10, null, 5, 0, 0, 0 },
                    { 11, null, 6, 0, 0, 1 },
                    { 12, null, 7, 0, 0, 2 },
                    { 13, null, 8, 0, 0, 0 },
                    { 14, null, 9, 0, 0, 1 },
                    { 15, null, 10, 0, 0, 2 },
                    { 16, null, 11, 0, 0, 0 },
                    { 17, null, 12, 0, 0, 1 },
                    { 18, null, 13, 0, 0, 2 },
                    { 19, null, 13, 0, 0, 0 },
                    { 20, null, 13, 0, 0, 1 },
                    { 21, null, 1, 0, 0, 1 },
                    { 22, null, 1, 0, 0, 1 },
                    { 23, null, 1, 0, 0, 2 },
                    { 24, null, 2, 0, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "ID", "RoomID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 4 },
                    { 8, 5 },
                    { 9, 5 },
                    { 10, 6 },
                    { 11, 6 },
                    { 12, 6 },
                    { 13, 7 },
                    { 14, 8 },
                    { 15, 8 },
                    { 16, 9 },
                    { 17, 9 },
                    { 18, 9 },
                    { 19, 10 },
                    { 20, 11 },
                    { 21, 11 },
                    { 22, 12 },
                    { 23, 12 },
                    { 24, 12 },
                    { 25, 13 },
                    { 26, 14 },
                    { 27, 14 },
                    { 28, 15 },
                    { 29, 15 },
                    { 30, 15 },
                    { 31, 16 },
                    { 32, 17 },
                    { 33, 17 },
                    { 34, 18 },
                    { 35, 18 },
                    { 36, 18 },
                    { 37, 19 },
                    { 38, 20 },
                    { 39, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                unique: true,
                filter: "[CustomerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomID",
                table: "Beds",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BranchID",
                table: "Bookings",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_HotelID",
                table: "Branches",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_BookingID",
                table: "CustomerBookings",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchID",
                table: "Employees",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingID",
                table: "Rooms",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BranchID",
                table: "Rooms",
                column: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "CustomerBookings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
