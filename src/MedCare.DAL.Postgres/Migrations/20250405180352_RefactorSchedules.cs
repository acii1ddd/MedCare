using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDate",
                table: "schedules");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "schedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkDate",
                table: "schedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
