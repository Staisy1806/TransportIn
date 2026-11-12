using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddSafeLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SafeLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LocationType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    HasSecurity = table.Column<bool>(type: "boolean", nullable: false),
                    HasParking = table.Column<bool>(type: "boolean", nullable: false),
                    HasFuel = table.Column<bool>(type: "boolean", nullable: false),
                    HasRepairService = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeLocations", x => x.Id);
                    table.CheckConstraint("CK_SafeLocations_Capacity", "\"Capacity\" IS NULL OR \"Capacity\" > 0");
                    table.CheckConstraint("CK_SafeLocations_Latitude", "\"Latitude\" >= -90 AND \"Latitude\" <= 90");
                    table.CheckConstraint("CK_SafeLocations_Longitude", "\"Longitude\" >= -180 AND \"Longitude\" <= 180");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SafeLocations_IsActive",
                table: "SafeLocations",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SafeLocations_Name",
                table: "SafeLocations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafeLocations");
        }
    }
}
