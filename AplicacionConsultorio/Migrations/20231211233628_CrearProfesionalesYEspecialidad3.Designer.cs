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
    [Migration("20231211233628_CrearProfesionalesYEspecialidad3")]
    partial class CrearProfesionalesYEspecialidad3
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

            modelBuilder.Entity("AplicacionConsultorio.Models.PacienteXObraSocial", b =>
                {
                    b.Property<int?>("IdObraSocial")
                        .HasColumnType("int");

                    b.Property<int?>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObraSocial", "IdPersona");

                    b.HasIndex("IdPersona");

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

                    b.Property<int?>("RolID")
                        .HasColumnType("int");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GeneroID");

                    b.HasIndex("RolID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EspecialidadID")
                        .HasColumnType("int");

                    b.Property<int>("PersonaID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fecha_registro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadID");

                    b.HasIndex("PersonaID");

                    b.ToTable("Profesional");
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
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Roles", "Rol")
                        .WithMany("Personas")
                        .HasForeignKey("RolID");

                    b.Navigation("Genero");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Profesional", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Especialidad", "Especialidad")
                        .WithMany("Profesionales")
                        .HasForeignKey("EspecialidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.Persona", "Persona")
                        .WithMany("Profesionales")
                        .HasForeignKey("PersonaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Especialidad", b =>
                {
                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Roles", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
