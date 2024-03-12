using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoGeneros
    {
        private readonly ConsultorioContext _context;

        public RepoGeneros(ConsultorioContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListaDeGeneros()
        {
            var items_generos = new List<SelectListItem>();
            items_generos = _context.Genero.Select(g => new SelectListItem()
            {
                Text = g.Nombre,
                Value = g.ID.ToString()
            }).ToList();
            return items_generos;
        }

        public Genero ObtenerGeneros(int id_genero)
        {
            return _context.Genero.Select(g => new Genero()
            {
                ID = g.ID,
                Nombre = g.Nombre,
            }).Where(g => g.ID == id_genero).FirstOrDefault();
        }
    }
}
