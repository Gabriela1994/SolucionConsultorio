using AplicacionConsultorio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoObraSociales
    {
        private readonly ConsultorioContext _context;

        public RepoObraSociales(ConsultorioContext context)
        {
            _context = context;
        }
        public List<SelectListItem> ListaDeObrasSociales()
        {
            var items_obrasSociales = new List<SelectListItem>();
            items_obrasSociales = _context.ObraSocial.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.ID.ToString()
            }).ToList();

            return items_obrasSociales;
        }
    }
}
