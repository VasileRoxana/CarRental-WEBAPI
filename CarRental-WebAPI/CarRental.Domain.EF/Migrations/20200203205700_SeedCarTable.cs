using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Domain.EF.Migrations
{
    public partial class SeedCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Capacity", "CarName", "CarType", "Price", "VehicleClass" },
                values: new object[] { 20, 2412, "BMW M5", 4, 251f, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
