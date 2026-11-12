using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleEquipments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEquipments", x => x.Id);
                    table.CheckConstraint("CK_VehicleEquipments_Quantity", "\"Quantity\" > 0");
                    table.ForeignKey(
                        name: "FK_VehicleEquipments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleEquipments",
                columns: new[] { "Id", "Description", "IsWorking", "Name", "Quantity", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Система отслеживания местоположения автомобиля", true, "GPS-трекер", 1, 1 },
                    { 2, "Ремни для фиксации перевозимого груза", true, "Ремни крепления груза", 10, 1 },
                    { 3, "Поддержание заданной температуры при перевозке", true, "Холодильная установка", 1, 2 },
                    { 4, "Оборудование для погрузки и разгрузки", true, "Гидроборт", 1, 3 },
                    { 5, "Средство пожарной безопасности", true, "Огнетушитель", 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEquipments_VehicleId",
                table: "VehicleEquipments",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleEquipments");
        }
    }
}
