using AplicacionConsultorio.Data;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using static AplicacionConsultorio.ViewModels.ProfesionalesViewModel;
using System.Collections.Generic;
using AplicacionConsultorio.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoProfesionales : IDisposable
    {
        private readonly ConsultorioContext _context;

        public RepoProfesionales(ConsultorioContext context)
        {
            _context = context;
        }

        public List<ListaDeProfesionales> ObtenerListaDeProfesionales()
        {
            List<ListaDeProfesionales> lista_profesionales = new List<ListaDeProfesionales>();

            using (_context)
            {
                lista_profesionales = (from prof in _context.ProfesionalXEspecialidad
                                       join p in _context.Persona
                                       on prof.IdPersona equals p.ID
                                       join e in _context.Especialidad
                                       on prof.IdEspecialidad equals e.ID
                                       select new ListaDeProfesionales
                                       {
                                           Nombre = p.Nombre,
                                           Apellido = p.Apellido,
                                           Dni = p.Dni,
                                           Genero = p.Genero.Nombre,
                                           Especialidad = e.Nombre

                                       }
                                  ).ToList();
            }
            return lista_profesionales;
        }

        public async void CrearProfesional(AgregarProfesional value_profesional, int id_persona, string rol)
        {
            try
            {
                const int rol_profesional = 1;
                var roles = Int32.Parse(rol);

                if (roles.Equals(rol_profesional))
                {
                    ProfesionalXEspecialidad profesional = new ProfesionalXEspecialidad
                    {
                        IdEspecialidad = value_profesional.IdEspecialidad,
                        IdPersona = id_persona,
                        Matricula_profesional = value_profesional.Matricula_profesional,
                        Detalles = value_profesional.Detalles
                    };

                    await _context.ProfesionalXEspecialidad.AddAsync(profesional);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                //
            }
        }
        public ProfesionalXEspecialidad DevuelvoProfesional(int id)
        {
            ProfesionalXEspecialidad profesional = new ProfesionalXEspecialidad();

            profesional = _context.ProfesionalXEspecialidad
                .Select(p => p)
                .Where(p => p.IdPersona == id)
                .FirstOrDefault();

            return profesional;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }    
}
