using System.Collections.Generic;
using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static AplicacionConsultorio.Controllers.ManagerPersonasController;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;

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

            return lista_personas;
        }
    }
}
