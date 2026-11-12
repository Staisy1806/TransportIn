using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AssignedDriver", "BodyType", "BrandModel", "CapacityTons", "HasRefrigerator", "Lat", "LicensePlate", "Lng", "Status", "VinCode", "VolumeM3" },
                values: new object[,]
                {
                    { 1, "Іван Водійченко", "Тент", "Mercedes-Benz Actros", 20.0, false, 50.450099999999999, "AA1234BC", 30.523399999999999, "Справний", "WDB96340310123456", 86.0 },
                    { 2, "Петро Дальнобій", "Рефрижератор", "Volvo FH", 22.0, true, 49.839700000000001, "BC5678DE", 24.029699999999998, "Справний", "YV2RT40A6KB123456", 90.0 },
                    { 3, "Не призначено", "Тент", "MAN TGX", 18.0, false, 46.482500000000002, "KA9012MH", 30.723299999999998, "На обслуговуванні", "WMA06XZZ9KP123456", 82.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
