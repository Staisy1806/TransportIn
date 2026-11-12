using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportIn.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlannedEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAssignments", x => x.Id);
                    table.CheckConstraint("CK_OrderAssignments_ActualPeriod", "\"ActualEnd\" IS NULL OR \"ActualStart\" IS NULL OR \"ActualEnd\" > \"ActualStart\"");
                    table.CheckConstraint("CK_OrderAssignments_PlannedPeriod", "\"PlannedEnd\" > \"PlannedStart\"");
                    table.ForeignKey(
                        name: "FK_OrderAssignments_Employees_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAssignments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAssignments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAssignments_DriverId_PlannedStart_PlannedEnd",
                table: "OrderAssignments",
                columns: new[] { "DriverId", "PlannedStart", "PlannedEnd" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAssignments_OrderId",
                table: "OrderAssignments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAssignments_VehicleId_PlannedStart_PlannedEnd",
                table: "OrderAssignments",
                columns: new[] { "VehicleId", "PlannedStart", "PlannedEnd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAssignments");
        }
    }
}
