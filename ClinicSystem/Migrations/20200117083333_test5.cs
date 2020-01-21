using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test5 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Billings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Billings_OrderId",
                table: "Billings",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Order_OrderId",
                table: "Billings",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Order_OrderId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_OrderId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Billings");

            migrationBuilder.AddColumn<int>(
                name: "DrugOrderId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
