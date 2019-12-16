using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorTreatment_Specialities_SpecialityID",
                table: "DoctorTreatment");

            migrationBuilder.RenameColumn(
                name: "SpecialityID",
                table: "DoctorTreatment",
                newName: "SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorTreatment_SpecialityID",
                table: "DoctorTreatment",
                newName: "IX_DoctorTreatment_SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorTreatment_Specialities_SpecialityId",
                table: "DoctorTreatment",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorTreatment_Specialities_SpecialityId",
                table: "DoctorTreatment");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "DoctorTreatment",
                newName: "SpecialityID");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorTreatment_SpecialityId",
                table: "DoctorTreatment",
                newName: "IX_DoctorTreatment_SpecialityID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorTreatment_Specialities_SpecialityID",
                table: "DoctorTreatment",
                column: "SpecialityID",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
