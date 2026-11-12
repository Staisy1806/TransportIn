using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedVehiclePlate", "CargoName", "CustomerCompany", "CustomerEmail", "CustomerName", "CustomerPhone", "DeliveryPoints", "LoadingPoints", "RequiresRefrigerator", "Status", "VolumeM3", "WeightTons" },
                values: new object[,]
                {
                    { 1, "BC5678DE", "Продукти харчування", "ТОВ АгроСвіт", "agrosvit@gmail.com", "Олександр Петренко", "+380501112233", new List<string> { "Львів", "Івано-Франківськ" }, new List<string> { "Київ" }, true, "В обробці", 45.0, 12.0 },
                    { 2, "AA1234BC", "Будівельні матеріали", "БудТрейд", "budtrade@gmail.com", "Андрій Коваленко", "+380671234567", new List<string> { "Київ" }, new List<string> { "Одеса" }, false, "Підтверджено", 65.0, 18.0 },
                    { 3, "BC5678DE", "Медичні препарати", "МедТех", "medtech@gmail.com", "Ірина Мельник", "+380931234567", new List<string> { "Дніпро", "Запоріжжя" }, new List<string> { "Харків" }, true, "Нове", 20.0, 5.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
