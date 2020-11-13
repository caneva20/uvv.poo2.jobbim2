using Microsoft.EntityFrameworkCore.Migrations;

namespace ajj.Migrations
{
    public partial class AddWorkloadToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Workload",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workload",
                table: "Courses");
        }
    }
}
