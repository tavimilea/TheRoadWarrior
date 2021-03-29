using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheRoadWarrior.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    LoginHash = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ReservationHash = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    TripName = table.Column<string>(type: "TEXT", nullable: true),
                    TravellerUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_TravellerUserId",
                        column: x => x.TravellerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    AmountAlreadyPaid = table.Column<float>(type: "REAL", nullable: false),
                    Observations = table.Column<string>(type: "TEXT", nullable: true),
                    AgencyUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CarModel = table.Column<string>(type: "TEXT", nullable: true),
                    CarRentalReservation_TripId = table.Column<int>(type: "INTEGER", nullable: true),
                    HotelName = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    StartingPeriod = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndingPeriod = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HotelReservation_TripId = table.Column<int>(type: "INTEGER", nullable: true),
                    TicketNumber = table.Column<string>(type: "TEXT", nullable: true),
                    FlightNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DepartingFrom = table.Column<string>(type: "TEXT", nullable: true),
                    ArrivingAt = table.Column<string>(type: "TEXT", nullable: true),
                    TripId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AgencyUsers_AgencyUserId",
                        column: x => x.AgencyUserId,
                        principalTable: "AgencyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_CarRentalReservation_TripId",
                        column: x => x.CarRentalReservation_TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_HotelReservation_TripId",
                        column: x => x.HotelReservation_TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AgencyUserId",
                table: "Reservations",
                column: "AgencyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarRentalReservation_TripId",
                table: "Reservations",
                column: "CarRentalReservation_TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelReservation_TripId",
                table: "Reservations",
                column: "HotelReservation_TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TravellerUserId",
                table: "Trips",
                column: "TravellerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AgencyUsers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
