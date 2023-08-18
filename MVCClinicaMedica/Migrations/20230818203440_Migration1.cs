using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
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
                name: "Operaciones",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreOperacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.idOperacion);
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
                    HistoriaClinica = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
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
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    idEspecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.idMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_idEspecialidad",
                        column: x => x.idEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "idEspecialidad",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Rol_Operaciones",
                columns: table => new
                {
                    idRolOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_Operaciones", x => x.idRolOperacion);
                    table.ForeignKey(
                        name: "FK_Rol_Operaciones_Operaciones_idOperacion",
                        column: x => x.idOperacion,
                        principalTable: "Operaciones",
                        principalColumn: "idOperacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rol_Operaciones_Roles_idRol",
                        column: x => x.idRol,
                        principalTable: "Roles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    idRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_idRol",
                        column: x => x.idRol,
                        principalTable: "Roles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Cascade);
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
                    idMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.idConsultorio);
                    table.ForeignKey(
                        name: "FK_Consultorios_Medicos_idMedico",
                        column: x => x.idMedico,
                        principalTable: "Medicos",
                        principalColumn: "idMedico",
                        onDelete: ReferentialAction.Cascade);
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
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    idConsultorio = table.Column<int>(type: "int", nullable: false),
                    idCita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.idFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Citas_idCita",
                        column: x => x.idCita,
                        principalTable: "Citas",
                        principalColumn: "idCita",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Facturas_Consultorios_idConsultorio",
                        column: x => x.idConsultorio,
                        principalTable: "Consultorios",
                        principalColumn: "idConsultorio",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Facturas_Pacientes_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_Consultorios_idMedico",
                table: "Consultorios",
                column: "idMedico");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposMedicosConsultorios_idConsultorio",
                table: "EquiposMedicosConsultorios",
                column: "idConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idCita",
                table: "Facturas",
                column: "idCita");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idConsultorio",
                table: "Facturas",
                column: "idConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idPaciente",
                table: "Facturas",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_idEspecialidad",
                table: "Medicos",
                column: "idEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosMedicos_idPaciente",
                table: "RegistrosMedicos",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Operaciones_idOperacion",
                table: "Rol_Operaciones",
                column: "idOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Operaciones_idRol",
                table: "Rol_Operaciones",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idRol",
                table: "Usuarios",
                column: "idRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquiposMedicosConsultorios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "RegistrosMedicos");

            migrationBuilder.DropTable(
                name: "Rol_Operaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EquiposMedicos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Roles");

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
