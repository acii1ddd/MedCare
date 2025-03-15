using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addShedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "user_profiles",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "user_profiles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportSeries",
                table: "user_profiles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleEntityUserEntity",
                columns: table => new
                {
                    SchedulesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntityUserEntity", x => new { x.SchedulesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ScheduleEntityUserEntity_schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEntityUserEntity_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntityUserEntity_UsersId",
                table: "ScheduleEntityUserEntity",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleEntityUserEntity");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "PassportSeries",
                table: "user_profiles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "users",
                type: "bytea",
                nullable: true);
        }
    }
}
