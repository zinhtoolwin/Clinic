using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBillDone",
                table: "Order");

            migrationBuilder.AddColumn<bool>(
                name: "IsBillDone",
                table: "Billings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBillDone",
                table: "Billings");

            migrationBuilder.AddColumn<bool>(
                name: "IsBillDone",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
