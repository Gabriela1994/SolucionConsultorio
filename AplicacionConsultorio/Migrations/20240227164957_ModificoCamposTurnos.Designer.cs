﻿// <auto-generated />
using System;
using AplicacionConsultorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    [DbContext(typeof(ConsultorioContext))]
    [Migration("20240227164957_ModificoCamposTurnos")]
    partial class ModificoCamposTurnos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AplicacionConsultorio.Models.Agenda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Duracion_consulta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora_llegada")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Hora_salida")
                        .HasColumnType("time");

                    b.Property<int>("ProfesionalIdPersona")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProfesionalIdPersona");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.DiaSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiaSemana");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Especialidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Estado_turno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Estado_turno");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ObraSocial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ObraSocial");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.PacienteXObraSocial", b =>
                {
                    b.Property<int?>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdObraSocial")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdPersona");

                    b.HasIndex("IdObraSocial");

                    b.ToTable("PacienteXObraSocial");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dni")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_secundario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolID")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GeneroId");

                    b.HasIndex("RolID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ProfesionalXEspecialidad", b =>
                {
                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int?>("IdEspecialidad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("detalles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("ProfesionalXEspecialidad");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Tipo_consulta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tipo_consulta");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Turno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Estado_turnoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_consulta")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora_consulta")
                        .HasColumnType("time");

                    b.Property<string>("Indicaciones_paciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteIdPersona")
                        .HasColumnType("int");

                    b.Property<int>("ProfesionalIdPersona")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_consultaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Estado_turnoID");

                    b.HasIndex("PacienteIdPersona");

                    b.HasIndex("ProfesionalIdPersona");

                    b.HasIndex("Tipo_consultaID");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Agenda", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.ProfesionalXEspecialidad", "Profesional")
                        .WithMany("Agenda")
                        .HasForeignKey("ProfesionalIdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.PacienteXObraSocial", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.ObraSocial", null)
                        .WithMany()
                        .HasForeignKey("IdObraSocial")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Persona", null)
                        .WithMany()
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Roles", "Rol")
                        .WithMany("Personas")
                        .HasForeignKey("RolID");

                    b.Navigation("Genero");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ProfesionalXEspecialidad", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Especialidad", null)
                        .WithMany()
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Persona", null)
                        .WithMany()
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Turno", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Estado_turno", "Estado_turno")
                        .WithMany("Turnos")
                        .HasForeignKey("Estado_turnoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.PacienteXObraSocial", "Paciente")
                        .WithMany("Turno")
                        .HasForeignKey("PacienteIdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.ProfesionalXEspecialidad", "Profesional")
                        .WithMany("Turno")
                        .HasForeignKey("ProfesionalIdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Tipo_consulta", "Tipo_consulta")
                        .WithMany("Turnos")
                        .HasForeignKey("Tipo_consultaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado_turno");

                    b.Navigation("Paciente");

                    b.Navigation("Profesional");

                    b.Navigation("Tipo_consulta");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Estado_turno", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.PacienteXObraSocial", b =>
                {
                    b.Navigation("Turno");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ProfesionalXEspecialidad", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Roles", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Tipo_consulta", b =>
                {
                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
