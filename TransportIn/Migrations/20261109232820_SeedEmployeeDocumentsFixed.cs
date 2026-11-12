using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeDocumentsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeDocuments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2032, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
