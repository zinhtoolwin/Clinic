using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSell_Drug_DrugId",
                table: "DrugSell");

            migrationBuilder.DropIndex(
                name: "IX_DrugSell_DrugId",
                table: "DrugSell");

            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "DrugSell");

            migrationBuilder.CreateTable(
                name: "DrugSellDrug",
                columns: table => new
                {
                    DrugId = table.Column<int>(nullable: false),
                    DrugsellId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSellDrug", x => new { x.DrugId, x.DrugsellId });
                    table.ForeignKey(
                        name: "FK_DrugSellDrug_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugSellDrug_DrugSell_DrugsellId",
                        column: x => x.DrugsellId,
                        principalTable: "DrugSell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugSellDrug_DrugsellId",
                table: "DrugSellDrug",
                column: "DrugsellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugSellDrug");

            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                table: "DrugSell",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DrugSell_DrugId",
                table: "DrugSell",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSell_Drug_DrugId",
                table: "DrugSell",
                column: "DrugId",
                principalTable: "Drug",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
