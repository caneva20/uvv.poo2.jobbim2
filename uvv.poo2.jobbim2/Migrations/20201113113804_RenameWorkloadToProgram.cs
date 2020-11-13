using Microsoft.EntityFrameworkCore.Migrations;

namespace ajj.Migrations
{
    public partial class RenameWorkloadToProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workload",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Program",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Workload",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
