using AplicacionConsultorio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using AplicacionConsultorio.Models;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoEspecialidades
    {
        private readonly ConsultorioContext _context;

        public RepoEspecialidades(ConsultorioContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListaDeEspecialidades()
        {
            var items_especialidades = new List<SelectListItem>();
            items_especialidades = _context.Especialidad.Select(e => new SelectListItem()
            {
                Text = e.Nombre,
                Value = e.ID.ToString()
            }).ToList();

            return items_especialidades;
        }        
        
        public List<Especialidad> ListaDeEspecialidades2()
        {
            var items_especialidades = new List<Especialidad>();
            items_especialidades = _context.Especialidad.Select(e => new Especialidad()
            {
                ID = e.ID,
                Nombre = e.Nombre.ToString(),
            }).ToList();

            return items_especialidades;
        }
    }
}
