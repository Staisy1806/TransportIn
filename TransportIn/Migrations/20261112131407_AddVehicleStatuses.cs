using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VehicleStatuses",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Транспорт доступний для призначення", true, "Вільний" },
                    { 2, "Транспорт призначений для виконання замовлення", true, "Призначений" },
                    { 3, "Транспорт прибув до місця завантаження", true, "Очікує завантаження" },
                    { 4, "Завантаження транспортного засобу завершено", true, "Завантажений" },
                    { 5, "Транспорт виконує маршрут", true, "У дорозі" },
                    { 6, "Виконується розвантаження", true, "Розвантажується" },
                    { 7, "Розвантаження завершено", true, "Розвантажений" },
                    { 8, "Транспорт перебуває на стоянці", true, "На стоянці" },
                    { 9, "Транспорт тимчасово не може виконувати замовлення", true, "Тимчасово недоступний" },
                    { 10, "Транспорт потребує технічного обслуговування", true, "Несправний" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleStatuses_Name",
                table: "VehicleStatuses",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleStatuses");
        }
    }
}
