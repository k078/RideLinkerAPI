using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.RL.Migrations
{
    /// <inheritdoc />
    public partial class UserTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "MobileNr", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[,]
                {
                    { "admin@mail.com", 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6012b634-2676-4b01-bfe4-4f9a5ba69555", false, 1, false, null, null, "Admin", null, null, "Admin1!", null, null, false, "8903e35e-f013-4428-b6fe-26eac50d2274", false, null, 0 },
                    { "hg@mail.com", 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6f01fdfc-5816-453e-9450-c638bb6c364e", false, 2, false, null, null, "Hans Gerard", null, null, "Password1!", null, null, false, "f97f715a-67e0-4426-aee4-369d94f1ff3a", false, null, 0 },
                    { "sten@mail.com", 0, new DateTime(2000, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "06e7b81f-0d5f-4c50-8fbe-bcb17c0bbe35", false, 3, false, null, null, "Sten", null, null, "Password1!", null, null, false, "476bdad1-38b1-41a1-9a81-07d1cb3feac2", false, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CarId", "DepartureId", "DestinationId", "DriverEmail", "DriverId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, null, null, "admin@mail.com", 1, new DateTime(2023, 12, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, null, null, "hg@mail.com", 2, new DateTime(2023, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, null, null, "hg@mail.com", 2, new DateTime(2023, 12, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 6, null, null, "hg@mail.com", 2, new DateTime(2023, 12, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, null, null, "sten@mail.com", 3, new DateTime(2023, 12, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, null, null, "sten@mail.com", 3, new DateTime(2023, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "admin@mail.com");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "hg@mail.com");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "sten@mail.com");
        }
    }
}
