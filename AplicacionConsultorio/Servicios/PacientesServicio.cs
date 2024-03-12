using AplicacionConsultorio.Data;
using AplicacionConsultorio.Repositorios;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Mvc;
using static AplicacionConsultorio.ViewModels.PacientesViewModel;

namespace AplicacionConsultorio.Servicios
{
    public class PacientesServicio
    {
        private readonly ConsultorioContext _context;

        public PacientesServicio(ConsultorioContext context)
        {
            _context = context;
        }

        public PacientePorDni EncontrarPaciente(int dni)
        {

            RepoPacientes repoPacientes = new RepoPacientes(_context);
            var paciente_encontrado = repoPacientes.BuscarPacientePorDni(dni);
            return paciente_encontrado;
        }
        
    }
}