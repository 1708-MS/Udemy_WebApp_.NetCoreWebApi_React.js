using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_WebApp.Infrastructure.Migrations
{
    public partial class AddedLevelModelAndLevelConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Level_LevelId",
                table: "Courses",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Level_LevelId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LevelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Courses");
        }
    }
}
