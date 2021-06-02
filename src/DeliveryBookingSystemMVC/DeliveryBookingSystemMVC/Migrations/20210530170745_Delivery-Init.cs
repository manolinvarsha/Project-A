using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryBookingSystemMVC.Migrations
{
    public partial class DeliveryInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryExecutives",
                columns: table => new
                {
                    ExecutiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryExecutives", x => x.ExecutiveId);
                });
            migrationBuilder.CreateTable(
               name: "Bookings",
               columns: table => new
               {
                   OrderId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   CustomerId = table.Column<int>(type: "int", nullable: false),
                   ExecutiveId = table.Column<int>(type: "int", nullable: false),
                   DateAndTimeOfPickup = table.Column<DateTime>(type: "datetime2", nullable: false),
                   WeightOfPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   PinCode = table.Column<int>(type: "int", nullable: false),
                   Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Price = table.Column<int>(type: "int", nullable: false),
                   Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Bookings", x => x.OrderId);
                   table.ForeignKey(
                      name: "FK_Bookings_Customers_CustomerId",
                      column: x => x.CustomerId,
                      principalTable: "Customers",
                      principalColumn: "CustomerId",
                      onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                      name: "FK_Bookings_DeliveryExecutives_ExecutiveId",
                      column: x => x.ExecutiveId,
                      principalTable: "DeliveryExecutives",
                      principalColumn: "ExecutiveId",
                      onDelete: ReferentialAction.Restrict);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DeliveryExecutives");
        }
    }
}
