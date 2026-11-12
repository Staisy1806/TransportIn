using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Password", "Phone", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Головний Адмін", "123", "+380000000001", 0, "admin" },
                    { 2, "Менеджер Складу", "123", "+380000000002", 1, "manager" },
                    { 3, "Водій Рефрижератора", "123", "+380000000003", 2, "driver" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
