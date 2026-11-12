using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedDriverSchedules : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DriverSchedules",
                columns: new[] { "Id", "EmployeeId", "EndTime", "IsAvailable", "Notes", "ShiftType", "StartTime", "WorkDate" },
                values: new object[,]
                {
            { 1, 1, new TimeSpan(0, 17, 0, 0, 0), true, "Основна денна зміна", "Денна", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2026, 11, 10, 0, 0, 0, DateTimeKind.Utc) },
            { 2, 2, new TimeSpan(0, 23, 0, 0, 0), true, "Вечірня зміна", "Вечірня", new TimeSpan(0, 16, 0, 0, 0), new DateTime(2026, 11, 10, 0, 0, 0, DateTimeKind.Utc) },
            { 3, 1, new TimeSpan(0, 17, 0, 0, 0), false, "Водій недоступний", "Денна", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2026, 11, 11, 0, 0, 0, DateTimeKind.Utc) }
                });
        }
    }
}
