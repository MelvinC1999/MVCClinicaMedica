using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_MedicosidMedico",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacientesidPaciente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_TiposPagos_TiposPagosidTipoPago",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_MedicosidMedico",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_PacientesidPaciente",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_TiposPagosidTipoPago",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "MedicosidMedico",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PacientesidPaciente",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "TiposPagosidTipoPago",
                table: "Citas");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_idMedico",
                table: "Citas",
                column: "idMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_idPaciente",
                table: "Citas",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_idTipoPago",
                table: "Citas",
                column: "idTipoPago");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_idMedico",
                table: "Citas",
                column: "idMedico",
                principalTable: "Medicos",
                principalColumn: "idMedico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_idPaciente",
                table: "Citas",
                column: "idPaciente",
                principalTable: "Pacientes",
                principalColumn: "idPaciente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_TiposPagos_idTipoPago",
                table: "Citas",
                column: "idTipoPago",
                principalTable: "TiposPagos",
                principalColumn: "idTipoPago",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_idMedico",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_idPaciente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_TiposPagos_idTipoPago",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idMedico",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idPaciente",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idTipoPago",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "MedicosidMedico",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacientesidPaciente",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TiposPagosidTipoPago",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MedicosidMedico",
                table: "Citas",
                column: "MedicosidMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacientesidPaciente",
                table: "Citas",
                column: "PacientesidPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_TiposPagosidTipoPago",
                table: "Citas",
                column: "TiposPagosidTipoPago");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_MedicosidMedico",
                table: "Citas",
                column: "MedicosidMedico",
                principalTable: "Medicos",
                principalColumn: "idMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacientesidPaciente",
                table: "Citas",
                column: "PacientesidPaciente",
                principalTable: "Pacientes",
                principalColumn: "idPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_TiposPagos_TiposPagosidTipoPago",
                table: "Citas",
                column: "TiposPagosidTipoPago",
                principalTable: "TiposPagos",
                principalColumn: "idTipoPago");
        }
    }
}
