using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSkills.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LessonAndModuleOrderNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Lessons");
        }
    }
}
