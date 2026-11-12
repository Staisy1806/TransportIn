using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialTransportRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransportRoutes",
                columns: new[] { "Id", "CargoId", "DriverId", "Latitude", "Longitude", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 50.450099999999999, 30.523399999999999, "У дорозі" },
                    { 2, 2, 2, 49.839700000000001, 24.029699999999998, "На складі" },
                    { 3, 3, 1, 46.482500000000002, 30.723299999999998, "Очікує відправлення" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransportRoutes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportRoutes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportRoutes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
