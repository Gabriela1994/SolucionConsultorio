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
    [Migration("20231205234239_MigracionObraSocial3")]
    partial class MigracionObraSocial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int?>("ObraSocialID")
                        .HasColumnType("int");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GeneroID");

                    b.HasIndex("ObraSocialID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Persona", b =>
                {
                    b.HasOne("AplicacionConsultorio.Models.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicacionConsultorio.Models.ObraSocial", "ObraSocial")
                        .WithMany("Personas")
                        .HasForeignKey("ObraSocialID");

                    b.Navigation("Genero");

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AplicacionConsultorio.Models.ObraSocial", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
