using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class vLS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquiposMedicos",
                columns: table => new
                {
                    idEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionEquipo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposMedicos", x => x.idEquipo);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    idEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.idEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.idPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "TiposPagos",
                columns: table => new
                {
                    idTipoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPagos", x => x.idTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    idMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EspecialidadesidEspecialidad = table.Column<int>(type: "int", nullable: true),
                    idEspecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.idMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadesidEspecialidad",
                        column: x => x.EspecialidadesidEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "idEspecialidad");
                });

            migrationBuilder.CreateTable(
                name: "RegistrosMedicos",
                columns: table => new
                {
                    idRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosMedicos", x => x.idRegistro);
                    table.ForeignKey(
                        name: "FK_RegistrosMedicos_Pacientes_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuariosidUsuario = table.Column<int>(type: "int", nullable: true),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    RolesidRol = table.Column<int>(type: "int", nullable: true),
                    idRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.idPerfil);
                    table.ForeignKey(
                        name: "FK_Perfiles_Roles_RolesidRol",
                        column: x => x.RolesidRol,
                        principalTable: "Roles",
                        principalColumn: "idRol");
                    table.ForeignKey(
                        name: "FK_Perfiles_Usuarios_UsuariosidUsuario",
                        column: x => x.UsuariosidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    idCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idMedico = table.Column<int>(type: "int", nullable: false),
                    idTipoPago = table.Column<int>(type: "int", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.idCita);
                    table.ForeignKey(
                        name: "FK_Citas_Medicos_idMedico",
                        column: x => x.idMedico,
                        principalTable: "Medicos",
                        principalColumn: "idMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_TiposPagos_idTipoPago",
                        column: x => x.idTipoPago,
                        principalTable: "TiposPagos",
                        principalColumn: "idTipoPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    idConsultorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioConsulta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MedicosidMedico = table.Column<int>(type: "int", nullable: true),
                    idMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.idConsultorio);
                    table.ForeignKey(
                        name: "FK_Consultorios_Medicos_MedicosidMedico",
                        column: x => x.MedicosidMedico,
                        principalTable: "Medicos",
                        principalColumn: "idMedico");
                });

            migrationBuilder.CreateTable(
                name: "EquiposMedicosConsultorios",
                columns: table => new
                {
                    idEquipo = table.Column<int>(type: "int", nullable: false),
                    idConsultorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposMedicosConsultorios", x => new { x.idEquipo, x.idConsultorio });
                    table.ForeignKey(
                        name: "FK_EquiposMedicosConsultorios_Consultorios_idConsultorio",
                        column: x => x.idConsultorio,
                        principalTable: "Consultorios",
                        principalColumn: "idConsultorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposMedicosConsultorios_EquiposMedicos_idEquipo",
                        column: x => x.idEquipo,
                        principalTable: "EquiposMedicos",
                        principalColumn: "idEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    idFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EstadoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PacientesidPaciente = table.Column<int>(type: "int", nullable: true),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    ConsultoriosidConsultorio = table.Column<int>(type: "int", nullable: true),
                    idConsultorio = table.Column<int>(type: "int", nullable: false),
                    CitasidCita = table.Column<int>(type: "int", nullable: true),
                    idCita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.idFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Citas_CitasidCita",
                        column: x => x.CitasidCita,
                        principalTable: "Citas",
                        principalColumn: "idCita");
                    table.ForeignKey(
                        name: "FK_Facturas_Consultorios_ConsultoriosidConsultorio",
                        column: x => x.ConsultoriosidConsultorio,
                        principalTable: "Consultorios",
                        principalColumn: "idConsultorio");
                    table.ForeignKey(
                        name: "FK_Facturas_Pacientes_PacientesidPaciente",
                        column: x => x.PacientesidPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "idPaciente");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Consultorios_MedicosidMedico",
                table: "Consultorios",
                column: "MedicosidMedico");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposMedicosConsultorios_idConsultorio",
                table: "EquiposMedicosConsultorios",
                column: "idConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_CitasidCita",
                table: "Facturas",
                column: "CitasidCita");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ConsultoriosidConsultorio",
                table: "Facturas",
                column: "ConsultoriosidConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PacientesidPaciente",
                table: "Facturas",
                column: "PacientesidPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadesidEspecialidad",
                table: "Medicos",
                column: "EspecialidadesidEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_RolesidRol",
                table: "Perfiles",
                column: "RolesidRol");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_UsuariosidUsuario",
                table: "Perfiles",
                column: "UsuariosidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosMedicos_idPaciente",
                table: "RegistrosMedicos",
                column: "idPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquiposMedicosConsultorios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "RegistrosMedicos");

            migrationBuilder.DropTable(
                name: "EquiposMedicos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TiposPagos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
