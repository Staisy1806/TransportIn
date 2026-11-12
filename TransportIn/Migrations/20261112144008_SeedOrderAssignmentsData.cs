using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderAssignmentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderAssignments",
                columns: new[] { "Id", "ActualEnd", "ActualStart", "AssignedAt", "DriverId", "Notes", "OrderId", "PlannedEnd", "PlannedStart", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2026, 11, 12, 9, 0, 0, 0, DateTimeKind.Utc), 1, "Перевезення продуктів харчування", 1, new DateTime(2026, 11, 15, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Призначено", 1 },
                    { 2, null, null, new DateTime(2026, 11, 12, 10, 0, 0, 0, DateTimeKind.Utc), 2, "Перевезення будівельних матеріалів", 2, new DateTime(2026, 11, 16, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 16, 8, 0, 0, 0, DateTimeKind.Utc), "Призначено", 2 },
                    { 3, null, null, new DateTime(2026, 11, 12, 11, 0, 0, 0, DateTimeKind.Utc), 3, "Перевезення медичних препаратів", 3, new DateTime(2026, 11, 17, 13, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 17, 9, 0, 0, 0, DateTimeKind.Utc), "Призначено", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderAssignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderAssignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderAssignments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
