using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddRuleExecutionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleExecutionHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpertRuleId = table.Column<int>(type: "integer", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    TriggerDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Result = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Details = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    WasSuccessful = table.Column<bool>(type: "boolean", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleExecutionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleExecutionHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RuleExecutionHistories_ExpertRules_ExpertRuleId",
                        column: x => x.ExpertRuleId,
                        principalTable: "ExpertRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleExecutionHistories_EmployeeId",
                table: "RuleExecutionHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleExecutionHistories_ExecutedAt",
                table: "RuleExecutionHistories",
                column: "ExecutedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RuleExecutionHistories_ExpertRuleId",
                table: "RuleExecutionHistories",
                column: "ExpertRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleExecutionHistories_WasSuccessful",
                table: "RuleExecutionHistories",
                column: "WasSuccessful");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleExecutionHistories");
        }
    }
}
