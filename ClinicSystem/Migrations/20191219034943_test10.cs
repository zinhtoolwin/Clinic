using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrugName",
                table: "DrugSell",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrugPrice",
                table: "DrugSell",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrugQty",
                table: "DrugSell",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_Amt",
                table: "DrugSell",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugName",
                table: "DrugSell");

            migrationBuilder.DropColumn(
                name: "DrugPrice",
                table: "DrugSell");

            migrationBuilder.DropColumn(
                name: "DrugQty",
                table: "DrugSell");

            migrationBuilder.DropColumn(
                name: "Total_Amt",
                table: "DrugSell");
        }
    }
}
