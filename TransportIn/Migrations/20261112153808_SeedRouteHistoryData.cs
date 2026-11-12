using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRouteHistoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RouteHistories",
                columns: new[] { "Id", "ChangedAt", "ChangedByEmployeeId", "Description", "NewStatus", "PreviousStatus", "RouteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 12, 9, 5, 0, 0, DateTimeKind.Utc), 1, "Маршрут створено для перевезення з Києва до Львова", "Створено", "", 1 },
                    { 2, new DateTime(2026, 11, 12, 9, 10, 0, 0, DateTimeKind.Utc), 1, "Маршрут заплановано", "Заплановано", "Створено", 1 },
                    { 3, new DateTime(2026, 11, 12, 10, 5, 0, 0, DateTimeKind.Utc), 2, "Маршрут створено для перевезення з Харкова до Дніпра", "Створено", "", 2 },
                    { 4, new DateTime(2026, 11, 12, 10, 10, 0, 0, DateTimeKind.Utc), 2, "Маршрут заплановано", "Заплановано", "Створено", 2 },
                    { 5, new DateTime(2026, 11, 12, 11, 5, 0, 0, DateTimeKind.Utc), 3, "Маршрут створено для перевезення з Одеси до Миколаєва", "Створено", "", 3 },
                    { 6, new DateTime(2026, 11, 12, 11, 10, 0, 0, DateTimeKind.Utc), 3, "Маршрут заплановано", "Заплановано", "Створено", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RouteHistories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
