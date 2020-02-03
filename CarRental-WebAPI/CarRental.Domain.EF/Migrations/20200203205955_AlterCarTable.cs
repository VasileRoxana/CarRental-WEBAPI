using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Domain.EF.Migrations
{
    public partial class AlterCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Capacity", "CarName", "CarType", "Price", "VehicleClass" },
                values: new object[] { 2, 1242, "BMW M1", 2, 2511f, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
