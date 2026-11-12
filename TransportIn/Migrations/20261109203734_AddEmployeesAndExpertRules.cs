using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeesAndExpertRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    LicenseCategory = table.Column<string>(type: "text", nullable: false),
                    MedicalCertExpiry = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThreatType = table.Column<string>(type: "text", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    ActionRecommendation = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertRules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FullName", "IsActive", "LicenseCategory", "MedicalCertExpiry", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "Іван Водійченко", true, "C, CE", "12.10.2026", "0501112233", "Водій" },
                    { 2, "Петро Дальнобій", true, "C1, C", "05.05.2027", "0672223344", "Водій" },
                    { 3, "Олена Менеджер", true, "-", "-", "0933334455", "Менеджер" }
                });

            migrationBuilder.InsertData(
                table: "ExpertRules",
                columns: new[] { "Id", "ActionRecommendation", "Condition", "Priority", "ThreatType" },
                values: new object[,]
                {
                    { 1, "Негайна зупинка, пошук безпечного місця або найближчої стоянки.", "Автомобіль в дорозі", "Критичний", "Повітряна тривога" },
                    { 2, "Діє обмеження Укравтодору. Перенесення руху на нічний час, відстій на TIR-парковках.", "Вага понад 24 тонни в денний час (10:00 - 22:00)", "Високий", "Аномальна спека (>+35°C)" },
                    { 3, "Зменшення швидкості руху, підвищена дистанція.", "Зниження коефіцієнта зчеплення", "Середній", "Ожеледиця" },
                    { 4, "Блокування автоматичної побудови маршруту через річку. Очікування відновлення руху.", "Критична інфраструктурна подія", "Критичний", "Закриття мостів (Правий / Лівий берег)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExpertRules");
        }
    }
}
