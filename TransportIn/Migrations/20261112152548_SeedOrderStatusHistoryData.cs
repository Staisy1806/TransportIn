using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderStatusHistoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatusHistories",
                columns: new[] { "Id", "ChangedAt", "ChangedByEmployeeId", "Comment", "NewStatus", "OrderId", "PreviousStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 10, 9, 0, 0, 0, DateTimeKind.Utc), 1, "Замовлення створено", "Створено", 1, "" },
                    { 2, new DateTime(2026, 11, 11, 10, 0, 0, 0, DateTimeKind.Utc), 1, "Замовлення підтверджено", "Підтверджено", 1, "Створено" },
                    { 3, new DateTime(2026, 11, 10, 11, 0, 0, 0, DateTimeKind.Utc), 2, "Замовлення створено", "Створено", 2, "" },
                    { 4, new DateTime(2026, 11, 11, 12, 0, 0, 0, DateTimeKind.Utc), 2, "Замовлення підтверджено", "Підтверджено", 2, "Створено" },
                    { 5, new DateTime(2026, 11, 10, 13, 0, 0, 0, DateTimeKind.Utc), 3, "Замовлення створено", "Створено", 3, "" },
                    { 6, new DateTime(2026, 11, 11, 14, 0, 0, 0, DateTimeKind.Utc), 3, "Замовлення підтверджено", "Підтверджено", 3, "Створено" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderStatusHistories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
