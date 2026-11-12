using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    DocumentType = table.Column<int>(type: "integer", nullable: false),
                    DocumentNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IssuedBy = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleDocuments",
                columns: new[] { "Id", "Details", "DocumentNumber", "DocumentType", "ExpiryDate", "IssueDate", "IssuedBy", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Свідоцтво про реєстрацію автомобіля", "REG-001", 0, new DateOnly(2034, 3, 15), new DateOnly(2024, 3, 15), "Сервісний центр МВС", 1 },
                    { 2, "Поліс обов'язкового страхування", "INS-001", 3, new DateOnly(2027, 1, 10), new DateOnly(2026, 1, 10), "Страхова компанія", 1 },
                    { 3, "Протокол технічного огляду", "TECH-002", 2, new DateOnly(2027, 2, 1), new DateOnly(2026, 2, 1), "Сервісний центр", 2 },
                    { 4, "Дозвіл на перевезення вантажів", "LIC-003", 4, new DateOnly(2027, 6, 20), new DateOnly(2025, 6, 20), "Уповноважений орган", 3 },
                    { 5, "Технічний паспорт транспортного засобу", "TP-004", 1, null, new DateOnly(2023, 9, 12), "Сервісний центр МВС", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VehicleId",
                table: "VehicleDocuments",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDocuments");
        }
    }
}
