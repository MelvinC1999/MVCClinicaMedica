﻿// <auto-generated />
using System;
using MVCClinicaMedica.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCClinicaMedica.Migrations
{
    [DbContext(typeof(BaseEFContext))]
    partial class BaseEFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<int>("idMedico")
                        .HasColumnType("int")
                        .HasColumnName("idMedico");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    b.Property<int>("idTipoPago")
                        .HasColumnType("int")
                        .HasColumnName("idTipoPago");

                    b.HasKey("idCita");

                    b.HasIndex("idMedico");

                    b.HasIndex("idPaciente");

                    b.HasIndex("idTipoPago");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.Property<int>("idConsultorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idConsultorio"));

                    b.Property<decimal>("PrecioConsulta")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("idMedico")
                        .HasColumnType("int")
                        .HasColumnName("idMedico");

                    b.HasKey("idConsultorio");

                    b.HasIndex("idMedico");

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
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DescripcionEquipo");

                    b.Property<string>("NombreEquipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NombreEquipo");

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
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Descripcion");

                    b.HasKey("idEspecialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Factura", b =>
                {
                    b.Property<int>("idFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFactura"));

                    b.Property<string>("EstadoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("idCita")
                        .HasColumnType("int")
                        .HasColumnName("idCita");

                    b.Property<int>("idConsultorio")
                        .HasColumnType("int")
                        .HasColumnName("idConsultorio");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    b.HasKey("idFactura");

                    b.HasIndex("idCita");

                    b.HasIndex("idConsultorio");

                    b.HasIndex("idPaciente");

                    b.ToTable("Facturas");
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
                        .HasColumnType("int")
                        .HasColumnName("idEspecialidad");

                    b.HasKey("idMedico");

                    b.HasIndex("idEspecialidad");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Operacion", b =>
                {
                    b.Property<int>("idOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOperacion"));

                    b.Property<string>("NombreOperacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idOperacion");

                    b.ToTable("Operaciones");
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

                    b.Property<string>("HistoriaClinica")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

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

            modelBuilder.Entity("MVCClinicaMedica.Models.RegistroMedico", b =>
                {
                    b.Property<int>("idRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRegistro"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    b.HasKey("idRegistro");

                    b.HasIndex("idPaciente");

                    b.ToTable("RegistrosMedicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Rol", b =>
                {
                    b.Property<int>("idRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRol"));

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.RolOperacion", b =>
                {
                    b.Property<int>("idRolOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRolOperacion"));

                    b.Property<int>("idOperacion")
                        .HasColumnType("int")
                        .HasColumnName("idOperacion");

                    b.Property<int>("idRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.HasKey("idRolOperacion");

                    b.HasIndex("idOperacion");

                    b.HasIndex("idRol");

                    b.ToTable("Rol_Operaciones");
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
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("idRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.HasKey("idUsuario");

                    b.HasIndex("idRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Cita", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Medico", "Medicos")
                        .WithMany()
                        .HasForeignKey("idMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany("Citas")
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.TipoPago", "TiposPagos")
                        .WithMany()
                        .HasForeignKey("idTipoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicos");

                    b.Navigation("Pacientes");

                    b.Navigation("TiposPagos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Medico", "Medicos")
                        .WithMany("Consultorios")
                        .HasForeignKey("idMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("idCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.Consultorio", "Consultorios")
                        .WithMany()
                        .HasForeignKey("idConsultorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany("Facturas")
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citas");

                    b.Navigation("Consultorios");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Medico", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Especialidad", "Especialidades")
                        .WithMany()
                        .HasForeignKey("idEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidades");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.RegistroMedico", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Paciente", "Pacientes")
                        .WithMany("RegistrosMedicos")
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.RolOperacion", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Operacion", "Operaciones")
                        .WithMany("RolOperaciones")
                        .HasForeignKey("idOperacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCClinicaMedica.Models.Rol", "Roles")
                        .WithMany("RolOperaciones")
                        .HasForeignKey("idRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operaciones");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Usuario", b =>
                {
                    b.HasOne("MVCClinicaMedica.Models.Rol", "Roles")
                        .WithMany("Usuarios")
                        .HasForeignKey("idRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Consultorio", b =>
                {
                    b.Navigation("EquiposMedicosConsultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.EquipoMedico", b =>
                {
                    b.Navigation("EquiposMedicosConsultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Medico", b =>
                {
                    b.Navigation("Consultorios");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Operacion", b =>
                {
                    b.Navigation("RolOperaciones");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Paciente", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Facturas");

                    b.Navigation("RegistrosMedicos");
                });

            modelBuilder.Entity("MVCClinicaMedica.Models.Rol", b =>
                {
                    b.Navigation("RolOperaciones");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
