using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_WebApp.Infrastructure.Migrations
{
    public partial class AddedLevelModelAndLevelConfigNewFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Level_LevelId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Level",
                table: "Level");

            migrationBuilder.RenameTable(
                name: "Level",
                newName: "Levels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Levels",
                table: "Levels",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Levels_LevelId",
                table: "Courses",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Levels_LevelId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Levels",
                table: "Levels");

            migrationBuilder.RenameTable(
                name: "Levels",
                newName: "Level");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Level",
                table: "Level",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Level_LevelId",
                table: "Courses",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
