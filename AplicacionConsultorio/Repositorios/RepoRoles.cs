using AplicacionConsultorio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoRoles
    {
        private readonly ConsultorioContext _context;

        public RepoRoles(ConsultorioContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListaDeRoles()
        {
            var items_roles = new List<SelectListItem>();
            items_roles = _context.Roles.Select(r => new SelectListItem()
            {
                Text = r.Nombre,
                Value = r.ID.ToString()
            }).ToList();
            return items_roles;
        }
    }
}
