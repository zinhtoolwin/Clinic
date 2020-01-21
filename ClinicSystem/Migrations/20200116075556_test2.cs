using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_DrugOrders_DrugOrderId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_DrugOrderId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "DrugOrderId",
                table: "Billings");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_DOrderId",
                table: "Billings",
                column: "DOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_DrugOrders_DOrderId",
                table: "Billings",
                column: "DOrderId",
                principalTable: "DrugOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_DrugOrders_DOrderId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_DOrderId",
                table: "Billings");

            migrationBuilder.AddColumn<int>(
                name: "DrugOrderId",
                table: "Billings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Billings_DrugOrderId",
                table: "Billings",
                column: "DrugOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_DrugOrders_DrugOrderId",
                table: "Billings",
                column: "DrugOrderId",
                principalTable: "DrugOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
