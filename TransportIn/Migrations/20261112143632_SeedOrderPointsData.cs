using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderPointsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderPoints",
                columns: new[] { "Id", "ActualArrival", "Address", "ContactName", "ContactPhone", "Latitude", "Longitude", "Notes", "OrderId", "PlannedArrival", "PointType", "SequenceNumber", "Status" },
                values: new object[,]
                {
                    { 1, null, "м. Київ, вул. Хрещатик, 10", "Олександр Петренко", "+380501112233", 50.450099999999999, 30.523399999999999, "Місце завантаження вантажу", 1, new DateTime(2026, 11, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Завантаження", 1, "Очікується" },
                    { 2, null, "м. Львів, вул. Городоцька, 20", "Іван Коваль", "+380671234567", 49.839700000000001, 24.029699999999998, "Місце отримання вантажу", 1, new DateTime(2026, 11, 15, 15, 0, 0, 0, DateTimeKind.Utc), "Розвантаження", 2, "Очікується" },
                    { 3, null, "м. Харків, вул. Сумська, 15", "Андрій Коваленко", "+380931234567", 49.993499999999997, 36.230400000000003, "Місце завантаження будівельних матеріалів", 2, new DateTime(2026, 11, 16, 8, 0, 0, 0, DateTimeKind.Utc), "Завантаження", 1, "Очікується" },
                    { 4, null, "м. Дніпро, просп. Дмитра Яворницького, 30", "Петро Мельник", "+380991234567", 48.464700000000001, 35.046199999999999, "Місце отримання будівельних матеріалів", 2, new DateTime(2026, 11, 16, 14, 0, 0, 0, DateTimeKind.Utc), "Розвантаження", 2, "Очікується" },
                    { 5, null, "м. Одеса, вул. Дерибасівська, 10", "Ірина Мельник", "+380931234568", 46.482500000000002, 30.723299999999998, "Місце завантаження медичних препаратів", 3, new DateTime(2026, 11, 17, 9, 0, 0, 0, DateTimeKind.Utc), "Завантаження", 1, "Очікується" },
                    { 6, null, "м. Миколаїв, вул. Соборна, 20", "Марія Шевченко", "+380991234568", 46.975000000000001, 31.994599999999998, "Місце отримання медичних препаратів", 3, new DateTime(2026, 11, 17, 13, 0, 0, 0, DateTimeKind.Utc), "Розвантаження", 2, "Очікується" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderPoints",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
