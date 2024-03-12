using System.Collections.Generic;
using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using static AplicacionConsultorio.ViewModels.PacientesViewModel;
using System;
using Microsoft.AspNetCore.Identity;
using NuGet.Versioning;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoPacientes
    {
        private readonly ConsultorioContext _context;

        public RepoPacientes(ConsultorioContext context)
        {
            _context = context;
        }

        public List<ListaDePacientes> ObtenerListaDePacientes()
        {
            List<ListaDePacientes> lista_personas = new List<ListaDePacientes>();

            using (_context)
            {
                lista_personas = (from pac in _context.PacienteXObraSocial
                                  join p in _context.Persona
                                  on pac.IdPersona equals p.ID
                                  join o in _context.ObraSocial
                                  on pac.IdObraSocial equals o.ID
                                  select new ListaDePacientes
                                  {
                                      Nombre = p.Nombre,
                                      Apellido = p.Apellido,
                                      Dni = p.Dni,
                                      Genero = p.Genero.Nombre,
                                      Obra_Social = o.Nombre,

                                  }
                                  ).ToList();
            }
            return lista_personas;
        }

        public async void CrearPaciente(AgregarPaciente value_paciente, int id_persona)
        {
            try
            {
                {
                    PacienteXObraSocial paciente = new PacienteXObraSocial
                    {
                        IdPersona = id_persona,
                        IdObraSocial = value_paciente.Id_ObraSocial,
                        Detalles = value_paciente.Detalles
                    };

                    await _context.PacienteXObraSocial.AddAsync(paciente);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }

        public PacientePorDni BuscarPacientePorDni(int dni)
        {
            PacientePorDni paciente_encontrado = new PacientePorDni();

            paciente_encontrado = (from p in _context.PacienteXObraSocial
                                   join persona in _context.Persona
                                   on p.IdPersona equals persona.ID
                                   where persona.Dni == dni
                                   select new PacientePorDni
                                   {
                                       Nombre = persona.Nombre,
                                       Nombre_secundario = persona.Nombre_secundario,
                                       Apellido = persona.Apellido,
                                       Dni = dni,
                                   }).FirstOrDefault();

            return paciente_encontrado;

        }        
        
        public PacienteXObraSocial BuscarPacientePorId(int id)
        {
            PacienteXObraSocial paciente_encontrado = new PacienteXObraSocial();

            paciente_encontrado = _context.PacienteXObraSocial.Find(id);

            return paciente_encontrado;

        }        
        
        public PacienteXObraSocial BuscarPacientePorDni2(int dni)
        {
            PacienteXObraSocial paciente_encontrado = new PacienteXObraSocial();

            paciente_encontrado = (from p in _context.PacienteXObraSocial
                                   join persona in _context.Persona on p.IdPersona equals persona.ID
                                   join obra in _context.ObraSocial on p.IdObraSocial equals obra.ID
                                   where persona.Dni == dni
                                   select p).First();

            return paciente_encontrado;

        }
    }
}
