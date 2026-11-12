using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRuleConditionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RuleConditions",
                columns: new[] { "Id", "Description", "ExpectedValue", "ExpertRuleId", "LogicalOperator", "Operator", "Parameter", "SequenceNumber" },
                values: new object[,]
                {
                    { 1, "Перевірка технічного стану автомобіля", "Несправний", 1, "AND", "==", "VehicleStatus", 1 },
                    { 2, "Перевірка статусу доставки", "Затримка", 2, "AND", "==", "DeliveryStatus", 1 },
                    { 3, "Перевірка наявності дорожньо-транспортної пригоди", "ДТП", 3, "AND", "==", "RoadEvent", 1 },
                    { 4, "Перевірка температури вантажу", "AllowedRange", 4, "AND", "OUT_OF_RANGE", "CargoTemperature", 1 },
                    { 5, "Перевірка часу останнього оновлення місцезнаходження", "30", 5, "AND", ">", "LastLocationUpdate", 1 },
                    { 6, "Перевірка ваги вантажу відносно вантажопідйомності автомобіля", "VehicleCapacity", 6, "AND", ">", "CargoWeight", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RuleConditions",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
