using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSkills.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DbSetModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleEntity_Courses_CourseId",
                table: "ModuleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleEntity",
                table: "ModuleEntity");

            migrationBuilder.RenameTable(
                name: "ModuleEntity",
                newName: "Modules");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleEntity_CourseId",
                table: "Modules",
                newName: "IX_Modules_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "ModuleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_CourseId",
                table: "ModuleEntity",
                newName: "IX_ModuleEntity_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleEntity",
                table: "ModuleEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleEntity_Courses_CourseId",
                table: "ModuleEntity",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
