﻿// <auto-generated />
using System;
using MVCClinicaMedica.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    [DbContext(typeof(BaseEFContext))]
    [Migration("20230811161048_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCClinicaMedica.Models.Cita", b =>
                {
                    b.Property<int>("idCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCita"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicosidMedico")
                        .HasColumnType("int");

                    b.Property<int?>("PacientesidPaciente")
                        .HasColumnType("int");

                    b.Property<int?>("TiposPagosidTipoPago")
                        .HasColumnType("int");

                    b.Property<int>("idMedico")
                        .HasColumnType("int");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<int>("idTipoPago")
                        .HasColumnType("int");

                    b.HasKey("idCita");

                    b.HasIndex("MedicosidMedico");

                    b.HasIndex("PacientesidPaciente");

                    b.HasIndex("TiposPagosidTipoPago");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.Property<int>("idConsultorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idConsultorio"));

                    b.Property<int?>("MedicosidMedico")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioConsulta")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("idMedico")
                        .HasColumnType("int");

                    b.HasKey("idConsultorio");

                    b.HasIndex("MedicosidMedico");

                    b.ToTable("Consultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.EquipoMedico", b =>
                {
                    b.Property<int>("idEquipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEquipo"));

                    b.Property<string>("DescripcionEquipo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NombreEquipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idEquipo");

                    b.ToTable("EquiposMedicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.EquipoMedicoConsultorio", b =>
                {
                    b.Property<int>("idEquipo")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("idConsultorio")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("idEquipo", "idConsultorio");

                    b.HasIndex("idConsultorio");

                    b.ToTable("EquiposMedicosConsultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Especialidad", b =>
                {
                    b.Property<int>("idEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEspecialidad"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idEspecialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Factura", b =>
                {
                    b.Property<int>("idFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFactura"));

                    b.Property<int?>("CitasidCita")
                        .HasColumnType("int");

                    b.Property<int?>("ConsultoriosidConsultorio")
                        .HasColumnType("int");

                    b.Property<string>("EstadoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("PacientesidPaciente")
                        .HasColumnType("int");

                    b.Property<int>("idCita")
                        .HasColumnType("int");

                    b.Property<int>("idConsultorio")
                        .HasColumnType("int");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.HasKey("idFactura");

                    b.HasIndex("CitasidCita");

                    b.HasIndex("ConsultoriosidConsultorio");

                    b.HasIndex("PacientesidPaciente");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.HistoriaClinica", b =>
                {
                    b.Property<int>("idHistoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idHistoria"));

                    b.Property<string>("Historial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PacientesidPaciente")
                        .HasColumnType("int");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.HasKey("idHistoria");

                    b.HasIndex("PacientesidPaciente");

                    b.ToTable("HistoriasClinicas");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Medico", b =>
                {
                    b.Property<int>("idMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMedico"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EspecialidadesidEspecialidad")
                        .HasColumnType("int");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("idEspecialidad")
                        .HasColumnType("int");

                    b.HasKey("idMedico");

                    b.HasIndex("EspecialidadesidEspecialidad");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Paciente", b =>
                {
                    b.Property<int>("idPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPaciente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("idPaciente");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Perfil", b =>
                {
                    b.Property<int>("idPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPerfil"));

                    b.Property<int?>("RolesidRol")
                        .HasColumnType("int");

                    b.Property<int?>("UsuariosidUsuario")
                        .HasColumnType("int");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("idPerfil");

                    b.HasIndex("RolesidRol");

                    b.HasIndex("UsuariosidUsuario");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.RegistroMedico", b =>
                {
                    b.Property<int>("idRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRegistro"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("HistoriasClinicasidHistoria")
                        .HasColumnType("int");

                    b.Property<int>("idHistoria")
                        .HasColumnType("int");

                    b.HasKey("idRegistro");

                    b.HasIndex("HistoriasClinicasidHistoria");

                    b.ToTable("RegistrosMedicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Rol", b =>
                {
                    b.Property<int>("idRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRol"));

                    b.Property<string>("DescripcionRol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.TipoPago", b =>
                {
                    b.Property<int>("idTipoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTipoPago"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idTipoPago");

                    b.ToTable("TiposPagos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Cita", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Medico", "Medicos")
                        .WithMany()
                        .HasForeignKey("MedicosidMedico");

                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany()
                        .HasForeignKey("PacientesidPaciente");

                    b.HasOne("MVCClinicaMedica.Models.TipoPago", "TiposPagos")
                        .WithMany()
                        .HasForeignKey("TiposPagosidTipoPago");

                    b.Navigation("Medicos");

                    b.Navigation("Pacientes");

                    b.Navigation("TiposPagos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Medico", "Medicos")
                        .WithMany()
                        .HasForeignKey("MedicosidMedico");

                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.EquipoMedicoConsultorio", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Consultorio", "Consultorios")
                        .WithMany("EquiposMedicosConsultorios")
                        .HasForeignKey("idConsultorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.EquipoMedico", "EquiposMedicos")
                        .WithMany("EquiposMedicosConsultorios")
                        .HasForeignKey("idEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultorios");

                    b.Navigation("EquiposMedicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Factura", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Cita", "Citas")
                        .WithMany()
                        .HasForeignKey("CitasidCita");

                    b.HasOne("MVCClinicaMedica.Models.Consultorio", "Consultorios")
                        .WithMany()
                        .HasForeignKey("ConsultoriosidConsultorio");

                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany()
                        .HasForeignKey("PacientesidPaciente");

                    b.Navigation("Citas");

                    b.Navigation("Consultorios");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.HistoriaClinica", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany()
                        .HasForeignKey("PacientesidPaciente");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Medico", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Especialidad", "Especialidades")
                        .WithMany()
                        .HasForeignKey("EspecialidadesidEspecialidad");

                    b.Navigation("Especialidades");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Perfil", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesidRol");

                    b.HasOne("MVCClinicaMedica.Models.Usuario", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosidUsuario");

                    b.Navigation("Roles");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.RegistroMedico", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.HistoriaClinica", "HistoriasClinicas")
                        .WithMany()
                        .HasForeignKey("HistoriasClinicasidHistoria");

                    b.Navigation("HistoriasClinicas");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.Navigation("EquiposMedicosConsultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.EquipoMedico", b =>
                {
                    b.Navigation("EquiposMedicosConsultorios");
                });
#pragma warning restore 612, 618
        }
    }
}
