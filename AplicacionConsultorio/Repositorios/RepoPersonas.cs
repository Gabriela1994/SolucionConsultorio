using AplicacionConsultorio.Data;
using System.Collections.Generic;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static AplicacionConsultorio.Controllers.ManagerPersonasController;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoPersonas
    {
        private readonly ConsultorioContext _context;

        public RepoPersonas(ConsultorioContext context)
        {
            _context = context;
        }
        public List<ListaDePersonas> ObtenerListaDePersonas()
        {
            List<ListaDePersonas> lista_personas = new List<ListaDePersonas>();

            using (_context)
            {
                lista_personas = (from p in _context.Persona
                                  select new ListaDePersonas
                                  {
                                      Id = p.ID,
                                      Nombre = p.Nombre,
                                      Apellido = p.Apellido,
                                      Dni = p.Dni,
                                      Genero = p.Genero.Nombre,
                                      Rol = p.Rol.Nombre
                                  }
                                  ).ToList();
            }
            return lista_personas;
        }

        public void CrearPersona(AgregarPersona value)
        {
            Persona persona = new Persona
            {
                Nombre = value.Nombre,
                Nombre_secundario = value.Nombre_secundario,
                Apellido = value.Apellido,
                Dni = value.Dni,
                Fecha_nacimiento = value.Fecha_nacimiento,
                Telefono = value.Telefono,
                Celular = value.Celular,
                Correo = value.Correo,
                Direccion = value.Direccion,
                Genero = value.Genero,
                Rol = value.Rol,
            };

            _context.Persona.Add(persona);
            _context.SaveChanges();
        }
        public int CreoPersonaYDevuelvoID(AgregarPersona value)
        {
            Persona persona = new Persona
            {
                Nombre = value.Nombre,
                Nombre_secundario = value.Nombre_secundario,
                Apellido = value.Apellido,
                Dni = value.Dni,
                Fecha_nacimiento = value.Fecha_nacimiento,
                Telefono = value.Telefono,
                Celular = value.Celular,
                Correo = value.Correo,
                Direccion = value.Direccion,
                Genero = value.Genero,
                Rol = value.Rol,
            };

            _context.Persona.Add(persona);                //persona2.Genero.ID = genero;
            _context.SaveChanges();
            return persona.ID;
        }

        public Genero DevuelvoGenero(string Genero)
        {
            var id_genero = Int32.Parse(Genero);
            var genero = _context.Genero.FirstOrDefault(g => g.ID == id_genero);
            return genero;
        }
        public Roles DevuelvoRol(string Roles)
        {
            var id_rol = Int32.Parse(Roles);
            var rol = _context.Roles.FirstOrDefault(r => r.ID == id_rol);
            return rol;
        }

        public void EditarPersona(AgregarPersona value, int id_persona)
        {
            Persona persona = new Persona();
            {
                persona = _context.Persona.Find(id_persona);

                persona.Nombre = value.Nombre;
                persona.Nombre_secundario = value.Nombre_secundario;
                persona.Apellido = value.Apellido;
                persona.Dni = value.Dni;
                persona.Fecha_nacimiento = value.Fecha_nacimiento;
                persona.Telefono = value.Telefono;
                persona.Celular = value.Celular;
                persona.Correo = value.Correo;
                persona.Direccion = value.Direccion;
                persona.Genero = value.Genero;
                persona.Rol = value.Rol;
            };
            _context.Entry(persona).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public Persona ObtenerPersona(int id)
        {
            var persona = _context.Persona.Find(id);

            return persona;
        }
        public Genero ObtenerPersonaYDevolverGenero(int id)
        {
            var persona = _context.Persona.Find(id);

            return persona.Genero;
        }
        public Roles ObtenerPersonaYDevolverRol(int id)
        {
            var persona = _context.Persona.Find(id);

            return persona.Rol;
        }

        public void EliminarPersona(int id)
        {
            var persona = _context.Persona.Find(id);

            _context.Persona.Remove(persona);
            _context.SaveChanges();
        }

        public string? FechaFormateada(int id)
        {
            Persona persona = _context.Persona.Find(id);
            var fecha = persona.Fecha_nacimiento;

            var dia = fecha.Value.Day;
            var mes = fecha.Value.Month;
            var año = fecha.Value.Year;

            return $"{dia}/{mes}/{año}".ToString();
        }
    }
}
