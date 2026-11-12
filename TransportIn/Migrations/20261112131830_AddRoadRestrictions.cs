using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddRoadRestrictions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestrictionType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    MaxWeightTons = table.Column<double>(type: "double precision", nullable: true),
                    MaxHeightMeters = table.Column<double>(type: "double precision", nullable: true),
                    MaxWidthMeters = table.Column<double>(type: "double precision", nullable: true),
                    MaxLengthMeters = table.Column<double>(type: "double precision", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadRestrictions", x => x.Id);
                    table.CheckConstraint("CK_RoadRestrictions_Dates", "\"EndedAt\" IS NULL OR \"EndedAt\" >= \"StartedAt\"");
                    table.CheckConstraint("CK_RoadRestrictions_Latitude", "\"Latitude\" IS NULL OR (\"Latitude\" >= -90 AND \"Latitude\" <= 90)");
                    table.CheckConstraint("CK_RoadRestrictions_Longitude", "\"Longitude\" IS NULL OR (\"Longitude\" >= -180 AND \"Longitude\" <= 180)");
                    table.CheckConstraint("CK_RoadRestrictions_MaxHeight", "\"MaxHeightMeters\" IS NULL OR \"MaxHeightMeters\" > 0");
                    table.CheckConstraint("CK_RoadRestrictions_MaxLength", "\"MaxLengthMeters\" IS NULL OR \"MaxLengthMeters\" > 0");
                    table.CheckConstraint("CK_RoadRestrictions_MaxWeight", "\"MaxWeightTons\" IS NULL OR \"MaxWeightTons\" > 0");
                    table.CheckConstraint("CK_RoadRestrictions_MaxWidth", "\"MaxWidthMeters\" IS NULL OR \"MaxWidthMeters\" > 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoadRestrictions_IsActive",
                table: "RoadRestrictions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RoadRestrictions_RestrictionType",
                table: "RoadRestrictions",
                column: "RestrictionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoadRestrictions");
        }
    }
}
