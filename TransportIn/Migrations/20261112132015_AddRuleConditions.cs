using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddRuleConditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpertRuleId = table.Column<int>(type: "integer", nullable: false),
                    Parameter = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Operator = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ExpectedValue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LogicalOperator = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleConditions", x => x.Id);
                    table.CheckConstraint("CK_RuleConditions_LogicalOperator", "\"LogicalOperator\" IN ('AND', 'OR')");
                    table.CheckConstraint("CK_RuleConditions_SequenceNumber", "\"SequenceNumber\" > 0");
                    table.ForeignKey(
                        name: "FK_RuleConditions_ExpertRules_ExpertRuleId",
                        column: x => x.ExpertRuleId,
                        principalTable: "ExpertRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleConditions_ExpertRuleId_SequenceNumber",
                table: "RuleConditions",
                columns: new[] { "ExpertRuleId", "SequenceNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleConditions");
        }
    }
}
