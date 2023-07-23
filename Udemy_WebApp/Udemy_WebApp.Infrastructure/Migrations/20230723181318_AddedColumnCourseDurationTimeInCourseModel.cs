using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_WebApp.Infrastructure.Migrations
{
    public partial class AddedColumnCourseDurationTimeInCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DurationTime(in Hours)",
                table: "Courses",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationTime(in Hours)",
                table: "Courses");
        }
    }
}
