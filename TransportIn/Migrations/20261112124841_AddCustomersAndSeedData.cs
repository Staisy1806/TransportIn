using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Edrpou = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CompanyName", "Edrpou", "Email", "IsActive", "Notes", "Phone" },
                values: new object[,]
                {
                    { 1, "м. Київ, вул. Хрещатик, 10", "ТОВ Логістик Плюс", "12345678", "logistic@example.com", true, "Постійний клієнт", "+380501112233" },
                    { 2, "м. Львів, вул. Зелена, 25", "ТОВ Агро Транс", "23456789", "agro@example.com", true, "Перевезення сільськогосподарської продукції", "+380671234567" },
                    { 3, "м. Одеса, вул. Промислова, 15", "ТОВ Будсервіс", "34567890", "build@example.com", true, "Перевезення будівельних матеріалів", "+380931234567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
