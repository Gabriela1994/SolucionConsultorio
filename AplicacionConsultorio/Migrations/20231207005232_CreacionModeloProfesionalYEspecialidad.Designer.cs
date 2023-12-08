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
    [Migration("20231207005232_CreacionModeloProfesionalYEspecialidad")]
    partial class CreacionModeloProfesionalYEspecialidad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("AplicacionConsultorio.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dni")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_secundario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocialID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaID")
                        .HasColumnType("int");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fecha_registro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GeneroID");

                    b.HasIndex("ObraSocialID");

                    b.HasIndex("PersonaID");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dni")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_secundario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GeneroID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dni")
                        .HasColumnType("int");

                    b.Property<int>("EspecialidadID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_secundario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fecha_registro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadID");

                    b.HasIndex("GeneroID");

                    b.ToTable("Profesional");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Paciente", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Genero", "Genero")
                        .WithMany("Pacientes")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.ObraSocial", "ObraSocial")
                        .WithMany("Pacientes")
                        .HasForeignKey("ObraSocialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Persona", null)
                        .WithMany("Pacientes")
                        .HasForeignKey("PersonaID");

                    b.Navigation("Genero");

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Profesional", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Especialidad", "Especialidad")
                        .WithMany("Profesionales")
                        .HasForeignKey("EspecialidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Genero", "Genero")
                        .WithMany("Profesionales")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Especialidad", b =>
                {
                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Navigation("Pacientes");

                    b.Navigation("Personas");

                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ObraSocial", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
