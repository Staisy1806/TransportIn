using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AssignedDriver", "BodyType", "BrandModel", "CapacityTons", "HasRefrigerator", "Lat", "LicensePlate", "Lng", "Status", "VinCode", "VolumeM3" },
                values: new object[,]
                {
                    { 4, "Не призначено", "Тент", "DAF XF 480", 20.0, false, 50.450099999999999, "KA4567OP", 30.523399999999999, "Справний", "XLRTE47MS0E123456", 90.0 },
                    { 5, "Не призначено", "Рефрижератор", "Scania R450", 21.0, true, 49.839700000000001, "BC7890KT", 24.029699999999998, "Справний", "YS2R4X20001234567", 88.0 },
                    { 6, "Не призначено", "Тент", "Renault T480", 18.0, false, 46.482500000000002, "AX2345MI", 30.723299999999998, "Справний", "VF611A168KD123456", 85.0 },
                    { 7, "Не призначено", "Рефрижератор", "MAN TGX 18.440", 18.0, true, 49.993499999999997, "KH5678BC", 36.230400000000003, "На обслуговуванні", "WMA06XZZ9KP654321", 80.0 },
                    { 8, "Не призначено", "Тент", "Iveco S-Way", 16.0, false, 48.464700000000001, "OD9012CA", 35.046199999999999, "Справний", "WJMM62AU00C123456", 75.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
