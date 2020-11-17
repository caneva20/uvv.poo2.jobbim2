using Microsoft.EntityFrameworkCore.Migrations;

namespace ajj.Migrations
{
    public partial class ChangedStatusToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Subscriptions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
