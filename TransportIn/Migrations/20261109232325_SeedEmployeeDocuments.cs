using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "WorkDate",
                table: "DriverSchedules",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkDate",
                value: new DateOnly(2026, 11, 10));

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkDate",
                value: new DateOnly(2026, 11, 10));

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "WorkDate" },
                values: new object[] { "Вихідний", new DateOnly(2026, 11, 11) });

            migrationBuilder.InsertData(
                table: "DriverSchedules",
                columns: new[] { "Id", "EmployeeId", "EndTime", "IsAvailable", "Notes", "ShiftType", "StartTime", "WorkDate" },
                values: new object[,]
                {
                    { 4, 2, new TimeSpan(0, 16, 0, 0, 0), true, "Робоча зміна", "Денна", new TimeSpan(0, 8, 0, 0, 0), new DateOnly(2026, 11, 11) },
                    { 5, 1, new TimeSpan(0, 18, 0, 0, 0), true, "Робоча зміна", "Денна", new TimeSpan(0, 9, 0, 0, 0), new DateOnly(2026, 11, 12) },
                    { 6, 2, new TimeSpan(0, 23, 0, 0, 0), true, "Вечірня зміна", "Вечірня", new TimeSpan(0, 16, 0, 0, 0), new DateOnly(2026, 11, 12) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeDocuments",
                columns: new[] { "Id", "Details", "DocumentNumber", "DocumentType", "EmployeeId", "ExpiryDate", "IssueDate", "IssuedBy" },
                values: new object[,]
                {
                    { 1, "Паспорт співробітника", "МР123456", 0, 1, null, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "МВС України" },
                    { 2, "Категорії C, CE", "АА123456", 4, 1, new DateTime(2032, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Сервісний центр МВС" },
                    { 3, "Документ про освіту", "EDU-2021-002", 2, 2, null, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Навчальний заклад" },
                    { 4, "Медична довідка", "MED-2026-003", 3, 3, new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Медичний заклад" }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkDate",
                table: "DriverSchedules",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkDate",
                value: new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkDate",
                value: new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DriverSchedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "WorkDate" },
                values: new object[] { "Водій недоступний", new DateTime(2026, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: 3);
        }
    }
}
