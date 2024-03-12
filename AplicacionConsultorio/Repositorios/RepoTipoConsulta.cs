using AplicacionConsultorio.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicacionConsultorio.Models;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoTipoConsulta
    {
        private readonly ConsultorioContext _context;

        public RepoTipoConsulta(ConsultorioContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListarTiposDeConsulta()
        {
            var tipos_consulta = new List<SelectListItem>();

            tipos_consulta = _context.Tipo_consulta.Select(r => new SelectListItem()
            {
                Text = r.Nombre,
                Value = r.ID.ToString()
            }).ToList();

            return tipos_consulta;
        }

        public Tipo_consulta BuscarTipoConsultaPorId(int id)
        {
            Tipo_consulta tipoConsulta = new Tipo_consulta();

            tipoConsulta = _context.Tipo_consulta.Find(id);

            return tipoConsulta;

        }
    }
}
