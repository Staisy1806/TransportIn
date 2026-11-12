using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoutePointsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "ActualArrival", "Address", "Latitude", "Longitude", "Notes", "PlannedArrival", "PointType", "RouteId", "SequenceNumber" },
                values: new object[,]
                {
                    { 1, null, "м. Київ, вул. Хрещатик, 10", null, null, "Початок маршруту", null, "Початкова", 1, 1 },
                    { 2, null, "м. Львів, вул. Городоцька, 20", null, null, "Кінцева точка маршруту", null, "Кінцева", 1, 2 },
                    { 3, null, "м. Харків, вул. Сумська, 15", null, null, "Початок маршруту", null, "Початкова", 2, 1 },
                    { 4, null, "м. Дніпро, просп. Дмитра Яворницького, 30", null, null, "Кінцева точка маршруту", null, "Кінцева", 2, 2 },
                    { 5, null, "м. Одеса, вул. Дерибасівська, 10", null, null, "Початок маршруту", null, "Початкова", 3, 1 },
                    { 6, null, "м. Миколаїв, вул. Соборна, 20", null, null, "Кінцева точка маршруту", null, "Кінцева", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
