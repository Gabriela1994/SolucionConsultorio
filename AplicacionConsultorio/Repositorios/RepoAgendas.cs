using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AplicacionConsultorio.ViewModels.AgendasViewModel;
using static AplicacionConsultorio.ViewModels.TurnosViewModel;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoAgendas
    {
        private readonly ConsultorioContext _context;

        public RepoAgendas(ConsultorioContext context)
        {
            _context = context;
        }

        public List<ListaDeAgendas> ListaDeAgendas()
        {
            List<ListaDeAgendas> lista_agendas = new List<ListaDeAgendas>();
            using (_context)
            {
                lista_agendas = (from a in _context.Agenda
                                 join p in _context.Persona
                                 on a.Profesional.IdPersona equals p.ID
                                 select new ListaDeAgendas
                                 {
                                     ID = a.ID,
                                     Nombre = p.Nombre,
                                     Apellido = p.Apellido,
                                     FechaInicio = a.FechaInicio,
                                     FechaFinal = a.FechaFinal,
                                     Hora_llegada = a.Hora_llegada,
                                     Hora_salida = a.Hora_salida,
                                     Duracion_consulta = a.Duracion_consulta,
                                     Id_profesional = a.Profesional.IdPersona
                                 }).ToList();
            }    
            return lista_agendas;
        }

        public string DevuelvoPersona()
        {
            Persona persona = new Persona();
            using(_context)
            {
                persona = (from pro in _context.ProfesionalXEspecialidad
                               join per in _context.Persona
                               on pro.IdPersona equals per.ID
                               select new Persona
                               {
                                   Nombre = per.Nombre,
                                   Apellido = per.Apellido
                               }).FirstOrDefault();
            }
            return persona.Nombre;
        }
        public List<ListaDeAgendasPorProfesional> ListaDeAgendaPorProfesional2(int id)
        {
            List<ListaDeAgendasPorProfesional> lista_agendas = new List<ListaDeAgendasPorProfesional>();

            using (_context)
            {

                lista_agendas = (from a in _context.Agenda
                          join p in _context.ProfesionalXEspecialidad
                          on a.Profesional.IdPersona equals p.IdPersona
                          join per in _context.Persona
                          on p.IdPersona equals per.ID
                          join e in _context.Especialidad
                          on p.IdEspecialidad equals e.ID
                          where a.Profesional.IdPersona == id
                          select new ListaDeAgendasPorProfesional
                          {
                              ID = a.ID,
                              Nombre = per.Nombre,
                              Apellido = per.Apellido,
                              Especialidad = e.Nombre,
                              FechaInicio = a.FechaInicio,
                              FechaFinal = a.FechaFinal,
                              Hora_llegada = a.Hora_llegada,
                              Hora_salida = a.Hora_salida,
                              Duracion_consulta = a.Duracion_consulta
                          }).ToList();
            }
            return lista_agendas;
        }

        public void CrearAgenda(CrearAgenda agenda_value, ProfesionalXEspecialidad profesional)
        {
            Agenda agenda = new Agenda();

            using (_context)
            {
                agenda.Profesional = profesional;
                agenda.FechaInicio = agenda_value.FechaInicio;
                agenda.FechaFinal = agenda_value.FechaFinal;
                agenda.Hora_llegada = agenda_value.Hora_llegada;
                agenda.Hora_salida = agenda_value.Hora_salida;
                agenda.Duracion_consulta = agenda_value.Duracion_consulta;

                _context.Agenda.Add(agenda);
                _context.SaveChanges();
            }
        }

        public void EliminarAgenda(int id)
        {
            Agenda agenda = new Agenda();
            using (_context)
            {
                agenda = _context.Agenda.Find(id);
                _context.Agenda.Remove(agenda);
                _context.SaveChanges();
            }
        }

        public List<SelectListItem> ListaDeProfesionalesConAgenda(int especialidad)
        
        {
            var lista_profesionales = new List<SelectListItem>();

            lista_profesionales = (from ag in _context.Agenda
                                   join profesional in _context.ProfesionalXEspecialidad on ag.Profesional.IdPersona equals profesional.IdPersona
                                   join persona in _context.Persona on profesional.IdPersona equals persona.ID
                                   where profesional.IdEspecialidad == especialidad
                                   select new SelectListItem
                                   {
                                       Text = (persona.Nombre.Humanize(LetterCasing.Title) + " " + persona.Apellido.Humanize(LetterCasing.Title)),
                                       Value = profesional.IdPersona.ToString()
                                   }).ToList();

            return lista_profesionales;
        }
        public List<ProfesionalesTurno> ListaDeProfesionalesConAgendaPorEspecialidad(int id_especialidad)

        {
            var lista_profesionales = new List<ProfesionalesTurno>();

            lista_profesionales = (from ag in _context.Agenda
                                   join profesional in _context.ProfesionalXEspecialidad on ag.Profesional.IdPersona equals profesional.IdPersona
                                   join persona in _context.Persona on profesional.IdPersona equals persona.ID
                                   where profesional.IdEspecialidad == id_especialidad
                                   select new ProfesionalesTurno
                                   {
                                       ID = profesional.IdPersona,
                                       Nombre_profesional = persona.Nombre,
                                       Apellido_profesional = persona.Apellido
                                   }).ToList();

            return lista_profesionales;
        }        
        public FechasProfesionalPorAgenda ListaHorariosDelProfesionalEnLaAgenda(int id_profesional, DateTime fechaInicio, DateTime fechaSalida)

        {
            var fecha_profesional = new FechasProfesionalPorAgenda();

            fecha_profesional = (from ag in _context.Agenda
                                 join profesional in _context.ProfesionalXEspecialidad on ag.Profesional.IdPersona equals profesional.IdPersona
                                 join persona in _context.Persona on profesional.IdPersona equals persona.ID
                                 where persona.ID == id_profesional
                                 select new FechasProfesionalPorAgenda
                                 {
                                     IdProfesional = persona.ID,
                                     Fecha_inicial = ag.FechaInicio,
                                     Fecha_final = ag.FechaFinal
                                 }).FirstOrDefault();
            return fecha_profesional;
        }
        
    }
}
