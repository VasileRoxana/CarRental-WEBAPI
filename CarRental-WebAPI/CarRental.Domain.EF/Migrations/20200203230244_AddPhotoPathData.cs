using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Domain.EF.Migrations
{
    public partial class AddPhotoPathData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "https://www.autocar.co.uk/sites/autocar.co.uk/files/styles/body-image/public/911-road-3629a.jpg?itok=m6x23Go0");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20,
                column: "PhotoPath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQAm1C05DaazFiRWcfM3m8FqayaOa-T64ushgHosW4gZwoJXUp1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20,
                column: "PhotoPath",
                value: null);
        }
    }
}
