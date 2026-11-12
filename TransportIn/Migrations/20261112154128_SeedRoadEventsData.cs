using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoadEventsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoadEvents",
                columns: new[] { "Id", "Address", "Description", "EndedAt", "EventType", "Latitude", "Longitude", "Severity", "StartedAt", "Title" },
                values: new object[,]
                {
                    { 1, "м. Київ, вул. Хрещатик", "Планові ремонтні роботи на ділянці дороги", new DateTime(2026, 11, 2, 18, 0, 0, 0, DateTimeKind.Utc), "Ремонт дороги", null, null, "Середній", new DateTime(2026, 11, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Ремонт дорожнього покриття" },
                    { 2, "м. Харків, вул. Сумська", "Тимчасове обмеження руху через проведення дорожніх робіт", new DateTime(2026, 11, 4, 17, 0, 0, 0, DateTimeKind.Utc), "Обмеження руху", null, null, "Низький", new DateTime(2026, 11, 3, 9, 0, 0, 0, DateTimeKind.Utc), "Тимчасове обмеження руху" },
                    { 3, "м. Одеса, вул. Дерибасівська", "Завершені роботи з відновлення дорожнього покриття", new DateTime(2026, 11, 6, 16, 0, 0, 0, DateTimeKind.Utc), "Дорожні роботи", null, null, "Середній", new DateTime(2026, 11, 5, 8, 0, 0, 0, DateTimeKind.Utc), "Ремонт дорожньої ділянки" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoadEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoadEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoadEvents",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
