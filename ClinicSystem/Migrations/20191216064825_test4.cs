using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: false),
                    SpecialityID = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    SchdeduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorTreatment_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorTreatment_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorTreatment_Schedules_SchdeduleId",
                        column: x => x.SchdeduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorTreatment_Specialities_SpecialityID",
                        column: x => x.SpecialityID,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTreatment_DoctorId",
                table: "DoctorTreatment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTreatment_PatientId",
                table: "DoctorTreatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTreatment_SchdeduleId",
                table: "DoctorTreatment",
                column: "SchdeduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTreatment_SpecialityID",
                table: "DoctorTreatment",
                column: "SpecialityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorTreatment");
        }
    }
}
