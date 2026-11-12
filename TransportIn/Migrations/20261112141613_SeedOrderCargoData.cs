using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderCargoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderCargos",
                columns: new[] { "Id", "CargoId", "Notes", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Основний вантаж замовлення", 1, 1 },
                    { 2, 2, "Будівельні матеріали", 2, 1 },
                    { 3, 3, "Медичні препарати", 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderCargos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderCargos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderCargos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
