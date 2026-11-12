using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoadRestrictionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoadRestrictions",
                columns: new[] { "Id", "Address", "Description", "EndedAt", "Latitude", "Longitude", "MaxHeightMeters", "MaxLengthMeters", "MaxWeightTons", "MaxWidthMeters", "RestrictionType", "StartedAt" },
                values: new object[,]
                {
                    { 1, "м. Київ, вул. Хрещатик", "Обмеження для транспортних засобів за максимальною масою", new DateTime(2026, 11, 2, 18, 0, 0, 0, DateTimeKind.Utc), null, null, null, null, 10.0, null, "Обмеження ваги", new DateTime(2026, 11, 1, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "м. Харків, вул. Сумська", "Обмеження висоти транспортних засобів", new DateTime(2026, 11, 4, 18, 0, 0, 0, DateTimeKind.Utc), null, null, 3.5, null, null, null, "Обмеження висоти", new DateTime(2026, 11, 3, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "м. Одеса, вул. Дерибасівська", "Обмеження ширини транспортних засобів", new DateTime(2026, 11, 6, 18, 0, 0, 0, DateTimeKind.Utc), null, null, null, null, null, 2.5, "Обмеження ширини", new DateTime(2026, 11, 5, 8, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoadRestrictions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoadRestrictions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoadRestrictions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
