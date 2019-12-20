using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DrugSell");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "DrugSell",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "DrugSell");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DrugSell",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
