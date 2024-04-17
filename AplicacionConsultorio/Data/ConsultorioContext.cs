using AplicacionConsultorio.Models;
using AplicacionConsultorio.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System;
using System.Reflection.Metadata;
using System.Xml;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicacionConsultorio.Data
{
    public class ConsultorioContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasMany(e => e.ObraSociales)
                .WithMany(e => e.Personas)
                .UsingEntity<PacienteXObraSocial>(
                    r => r.HasOne<ObraSocial>().WithMany().HasForeignKey(e => e.IdObraSocial).OnDelete(DeleteBehavior.NoAction),
                    l => l.HasOne<Persona>().WithMany().HasForeignKey(e => e.IdPersona).OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Especialidades)
                .WithMany(e => e.Personas)
                .UsingEntity<ProfesionalXEspecialidad>(
                    r => r.HasOne<Especialidad>().WithMany().HasForeignKey(e => e.IdEspecialidad).OnDelete(DeleteBehavior.NoAction),
                    l => l.HasOne<Persona>().WithMany().HasForeignKey(e => e.IdPersona).OnDelete(DeleteBehavior.NoAction)

                );

            //modelBuilder.Entity<Persona>()
            //.HasKey(p => p.ID)
            //.HasName("PrimaryKey_ID");

            modelBuilder.Entity<PacienteXObraSocial>()
            .HasKey(p => p.IdPersona);
            modelBuilder.Entity<ProfesionalXEspecialidad>()
            .HasKey(p => p.IdPersona);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();
        }
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        {
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<ObraSocial> ObraSocial { get; set; }
        public DbSet<PacienteXObraSocial> PacienteXObraSocial { get; set; }
        public DbSet<ProfesionalXEspecialidad> ProfesionalXEspecialidad { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Tipo_consulta> Tipo_consulta { get; set; }
        public DbSet<Estado_turno> EstadoTurno { get; set; }

    }
}

