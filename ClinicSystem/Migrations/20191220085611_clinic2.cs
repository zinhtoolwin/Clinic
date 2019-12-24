using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class clinic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrug_Drugs_DrugId",
                table: "DrugSellDrug");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrug_DrugSells_DrugsellId",
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

            migrationBuilder.CreateTable(
                name: "DoctorOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorOrders_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorOrders_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorOrderDrugs",
                columns: table => new
                {
                    DoctorOrderId = table.Column<int>(nullable: false),
                    DrugId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOrderDrugs", x => new { x.DoctorOrderId, x.DrugId });
                    table.ForeignKey(
                        name: "FK_DoctorOrderDrugs_DoctorOrders_DoctorOrderId",
                        column: x => x.DoctorOrderId,
                        principalTable: "DoctorOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorOrderDrugs_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOrderDrugs_DrugId",
                table: "DoctorOrderDrugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOrders_DoctorId",
                table: "DoctorOrders",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOrders_PatientId",
                table: "DoctorOrders",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_Drugs_DrugId",
                table: "DrugSellDrugs",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "DrugId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrugs_DrugSells_DrugsellId",
                table: "DrugSellDrugs",
                column: "DrugsellId",
                principalTable: "DrugSells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_Drugs_DrugId",
                table: "DrugSellDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugSellDrugs_DrugSells_DrugsellId",
                table: "DrugSellDrugs");

            migrationBuilder.DropTable(
                name: "DoctorOrderDrugs");

            migrationBuilder.DropTable(
                name: "DoctorOrders");

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
                name: "FK_DrugSellDrug_Drugs_DrugId",
                table: "DrugSellDrug",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "DrugId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugSellDrug_DrugSells_DrugsellId",
                table: "DrugSellDrug",
                column: "DrugsellId",
                principalTable: "DrugSells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
