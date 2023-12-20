using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.RL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "LocationId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpgp");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "LocationId",
                value: 1);
        }
    }
}
