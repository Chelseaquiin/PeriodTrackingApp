using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ImproveduserandaddedperiodDetailentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "PeriodDetails",
                columns: table => new
                {
                    PeriodDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodLength = table.Column<int>(type: "int", nullable: false),
                    CycleLength = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodDetails", x => x.PeriodDetailId);
                    table.ForeignKey(
                        name: "FK_PeriodDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDetails_UserId",
                table: "PeriodDetails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");
        }
    }
}
