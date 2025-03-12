using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRoleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "workers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "workers");
        }
    }
}
