using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoHorarios
    {
        private readonly ConsultorioContext _context;

        public RepoHorarios(ConsultorioContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListaDeHorarios()
        {
            var lista_horarios = new List<SelectListItem>();

            lista_horarios = _context.Horario.Select(r => new SelectListItem()
            {
                Text = r.Hora,
                Value = r.Id.ToString()
            }).ToList();

            return lista_horarios;

        }

        public Horario BuscarHorarioPorId(int id)
        {
            Horario horario_encontrado = new Horario();

            horario_encontrado = _context.Horario.Find(id);

            return horario_encontrado;

        }
    }
}
