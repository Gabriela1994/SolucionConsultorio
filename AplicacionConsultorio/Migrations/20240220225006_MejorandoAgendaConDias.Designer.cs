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
    [Migration("20240220225006_MejorandoAgendaConDias")]
    partial class MejorandoAgendaConDias
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

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.DiaSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgendasID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgendasID");

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
                    b.Property<int?>("IdPersona")
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

            modelBuilder.Entity("AplicacionConsultorio.Models.DiaSemana", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Agenda", "Agendas")
                        .WithMany("Semana")
                        .HasForeignKey("AgendasID");

                    b.Navigation("Agendas");
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

            modelBuilder.Entity("AplicacionConsultorio.Models.Agenda", b =>
                {
                    b.Navigation("Semana");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Roles", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
