using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drug",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drug");

            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                table: "Drug",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drug",
                table: "Drug",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs",
                column: "DrugId",
                principalTable: "Drug",
                principalColumn: "DrugId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drug",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "Drug");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drug",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drug",
                table: "Drug",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs",
                column: "DrugId",
                principalTable: "Drug",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
