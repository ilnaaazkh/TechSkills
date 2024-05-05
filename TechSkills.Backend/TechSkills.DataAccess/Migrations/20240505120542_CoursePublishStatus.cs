using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSkills.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CoursePublishStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublishState",
                table: "Courses",
                type: "int",
                nullable: true,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishState",
                table: "Courses");
        }
    }
}
