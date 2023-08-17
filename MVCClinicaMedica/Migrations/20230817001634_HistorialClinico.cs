using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class HistorialClinico : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosMedicos_HistoriasClinicas_HistoriasClinicasidHistoria",
                table: "RegistrosMedicos");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosMedicos_HistoriasClinicasidHistoria",
                table: "RegistrosMedicos");

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
                name: "HistoriasClinicasidHistoria",
                table: "RegistrosMedicos");

            migrationBuilder.DropColumn(
                name: "MedicosidMedico",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PacientesidPaciente",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "TiposPagosidTipoPago",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "idHistoria",
                table: "RegistrosMedicos",
                newName: "idPaciente");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "RegistrosMedicos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "RegistrosMedicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HistoriaClinica",
                table: "Pacientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosMedicos_idPaciente",
                table: "RegistrosMedicos",
                column: "idPaciente");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosMedicos_Pacientes_idPaciente",
                table: "RegistrosMedicos",
                column: "idPaciente",
                principalTable: "Pacientes",
                principalColumn: "idPaciente",
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

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosMedicos_Pacientes_idPaciente",
                table: "RegistrosMedicos");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosMedicos_idPaciente",
                table: "RegistrosMedicos");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idMedico",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idPaciente",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idTipoPago",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "RegistrosMedicos");

            migrationBuilder.DropColumn(
                name: "HistoriaClinica",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "idPaciente",
                table: "RegistrosMedicos",
                newName: "idHistoria");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "RegistrosMedicos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "HistoriasClinicasidHistoria",
                table: "RegistrosMedicos",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    idHistoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientesidPaciente = table.Column<int>(type: "int", nullable: true),
                    Historial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.idHistoria);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Pacientes_PacientesidPaciente",
                        column: x => x.PacientesidPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "idPaciente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosMedicos_HistoriasClinicasidHistoria",
                table: "RegistrosMedicos",
                column: "HistoriasClinicasidHistoria");

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

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacientesidPaciente",
                table: "HistoriasClinicas",
                column: "PacientesidPaciente");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosMedicos_HistoriasClinicas_HistoriasClinicasidHistoria",
                table: "RegistrosMedicos",
                column: "HistoriasClinicasidHistoria",
                principalTable: "HistoriasClinicas",
                principalColumn: "idHistoria");
        }
    }
}
