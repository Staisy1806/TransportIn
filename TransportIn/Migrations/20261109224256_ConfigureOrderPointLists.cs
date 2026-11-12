using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureOrderPointLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoadingPoints",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPoints",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { "[\"\\u041B\\u044C\\u0432\\u0456\\u0432\",\"\\u0406\\u0432\\u0430\\u043D\\u043E-\\u0424\\u0440\\u0430\\u043D\\u043A\\u0456\\u0432\\u0441\\u044C\\u043A\"]", "[\"\\u041A\\u0438\\u0457\\u0432\"]" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { "[\"\\u041A\\u0438\\u0457\\u0432\"]", "[\"\\u041E\\u0434\\u0435\\u0441\\u0430\"]" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { "[\"\\u0414\\u043D\\u0456\\u043F\\u0440\\u043E\",\"\\u0417\\u0430\\u043F\\u043E\\u0440\\u0456\\u0436\\u0436\\u044F\"]", "[\"\\u0425\\u0430\\u0440\\u043A\\u0456\\u0432\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "LoadingPoints",
                table: "Orders",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<string>>(
                name: "DeliveryPoints",
                table: "Orders",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { new List<string> { "Львів", "Івано-Франківськ" }, new List<string> { "Київ" } });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { new List<string> { "Київ" }, new List<string> { "Одеса" } });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeliveryPoints", "LoadingPoints" },
                values: new object[] { new List<string> { "Дніпро", "Запоріжжя" }, new List<string> { "Харків" } });
        }
    }
}
