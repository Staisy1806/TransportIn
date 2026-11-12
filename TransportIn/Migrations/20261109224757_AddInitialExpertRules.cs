using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialExpertRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExpertRules",
                columns: new[] { "Id", "ActionRecommendation", "Condition", "Priority", "ThreatType" },
                values: new object[,]
                {
                    { 1, "Направити автомобіль на технічний огляд та підібрати заміну", "Автомобіль несправний", "Високий", "Поломка транспорту" },
                    { 2, "Перевірити маршрут та повідомити менеджера", "Перевищено запланований час доставки", "Середній", "Затримка доставки" },
                    { 3, "Повідомити відповідального менеджера та організувати допомогу", "Зафіксовано дорожньо-транспортну пригоду", "Критичний", "Аварійна ситуація" },
                    { 4, "Перевірити холодильне обладнання та стан вантажу", "Температура вантажу виходить за допустимі межі", "Високий", "Порушення температурного режиму" },
                    { 5, "Перевірити останнє місцезнаходження та спробувати альтернативний зв'язок", "Відсутній зв'язок із водієм", "Високий", "Втрата зв'язку" },
                    { 6, "Перерозподілити вантаж або підібрати інший транспорт", "Вага вантажу перевищує вантажопідйомність автомобіля", "Високий", "Перевантаження автомобіля" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpertRules",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
