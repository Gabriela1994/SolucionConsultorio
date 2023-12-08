using AplicacionConsultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionConsultorio.Data
{
    public class ConsultorioContext : DbContext
    {
            public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
            {
            }

            public DbSet<Genero> Genero { get; set; }
            public DbSet<Persona> Persona { get; set; }
            public DbSet<Persona> Roles { get; set; }
            public DbSet<Persona> Paciente { get; set; }
            public DbSet<ObraSocial> ObraSocial { get; set; }
        }
    }

