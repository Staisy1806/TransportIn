using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoutesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "CreatedAt", "DistanceKm", "EndPoint", "EstimatedDurationMinutes", "OrderId", "StartPoint", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 12, 9, 0, 0, 0, DateTimeKind.Utc), 540.0, "м. Львів, вул. Городоцька, 20", 420, 1, "м. Київ, вул. Хрещатик, 10", "Заплановано", 1 },
                    { 2, new DateTime(2026, 11, 12, 10, 0, 0, 0, DateTimeKind.Utc), 220.0, "м. Дніпро, просп. Дмитра Яворницького, 30", 180, 2, "м. Харків, вул. Сумська, 15", "Заплановано", 2 },
                    { 3, new DateTime(2026, 11, 12, 11, 0, 0, 0, DateTimeKind.Utc), 135.0, "м. Миколаїв, вул. Соборна, 20", 120, 3, "м. Одеса, вул. Дерибасівська, 10", "Заплановано", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
