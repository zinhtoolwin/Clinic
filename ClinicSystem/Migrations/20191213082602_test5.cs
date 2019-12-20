using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrug_Drug_DrugId",
                table: "DrugSellDrug");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrug_DrugSell_DrugsellId",
                table: "DrugSellDrug");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrugSellDrug",
                table: "DrugSellDrug");

            migrationBuilder.RenameTable(
                name: "DrugSellDrug",
                newName: "DrugSellDrugs");

            migrationBuilder.RenameIndex(
                name: "IX_DrugSellDrug_DrugsellId",
                table: "DrugSellDrugs",
                newName: "IX_DrugSellDrugs_DrugsellId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrugSellDrugs",
                table: "DrugSellDrugs",
                columns: new[] { "DrugId", "DrugsellId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs",
                column: "DrugId",
                principalTable: "Drug",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_DrugSell_DrugsellId",
                table: "DrugSellDrugs",
                column: "DrugsellId",
                principalTable: "DrugSell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_Drug_DrugId",
                table: "DrugSellDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_DrugSell_DrugsellId",
                table: "DrugSellDrugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrugSellDrugs",
                table: "DrugSellDrugs");

            migrationBuilder.RenameTable(
                name: "DrugSellDrugs",
                newName: "DrugSellDrug");

            migrationBuilder.RenameIndex(
                name: "IX_DrugSellDrugs_DrugsellId",
                table: "DrugSellDrug",
                newName: "IX_DrugSellDrug_DrugsellId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrugSellDrug",
                table: "DrugSellDrug",
                columns: new[] { "DrugId", "DrugsellId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrug_Drug_DrugId",
                table: "DrugSellDrug",
                column: "DrugId",
                principalTable: "Drug",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrug_DrugSell_DrugsellId",
                table: "DrugSellDrug",
                column: "DrugsellId",
                principalTable: "DrugSell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
