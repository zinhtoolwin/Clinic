using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "DrugSell");

            migrationBuilder.DropColumn(
                name: "NoofDay",
                table: "DrugSell");

            migrationBuilder.AddColumn<int>(
                name: "Total_Price",
                table: "DrugSell",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total_Price",
                table: "DrugSell");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "DrugSell",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoofDay",
                table: "DrugSell",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
