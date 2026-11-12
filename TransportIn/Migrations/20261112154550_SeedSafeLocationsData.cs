using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedSafeLocationsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SafeLocations",
                columns: new[] { "Id", "Address", "Capacity", "Description", "HasFuel", "HasParking", "HasRepairService", "HasSecurity", "IsActive", "Latitude", "LocationType", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Киев, ул. Большая Васильковская, 100", 50, "Охраняемая стоянка для грузового транспорта", true, true, false, true, true, 50.421199999999999, "Стоянка", 30.5167, "Охраняемая стоянка Киев" },
                    { 2, "Львов, ул. Городоцкая, 300", 30, "Площадка для стоянки, заправки и обслуживания транспорта", true, true, true, true, true, 49.839700000000001, "Транспортный центр", 24.029699999999998, "Транспортный центр Львов" },
                    { 3, "Одесса, ул. Атамана Головатого, 50", 20, "Площадка для временной безопасной стоянки транспорта", false, true, false, true, true, 46.482500000000002, "Площадка", 30.723299999999998, "Безопасная площадка Одесса" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SafeLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SafeLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SafeLocations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
