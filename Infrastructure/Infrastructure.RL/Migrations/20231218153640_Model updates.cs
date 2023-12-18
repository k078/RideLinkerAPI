using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.RL.Migrations
{
    /// <inheritdoc />
    public partial class Modelupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Trips_TripId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserEmail",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_TripId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserEmail",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureId",
                table: "Trips",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_DepartureId",
                table: "Trips",
                column: "DepartureId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_DestinationId",
                table: "Trips",
                column: "DestinationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_DepartureId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_DestinationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DepartureId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Trips");

            migrationBuilder.AddColumn<string>(
                name: "Departure",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TripId",
                table: "Locations",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserEmail",
                table: "Locations",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Trips_TripId",
                table: "Locations",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserEmail",
                table: "Locations",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email");
        }
    }
}
