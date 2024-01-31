using AplicacionConsultorio.Models;
using Microsoft.EntityFrameworkCore;

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
        }
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        {
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Profesional> Profesional { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
           
        public DbSet<ObraSocial> ObraSocial { get; set; }
        public DbSet<PacienteXObraSocial> PacienteXObraSocial { get; set; }


    }
}

