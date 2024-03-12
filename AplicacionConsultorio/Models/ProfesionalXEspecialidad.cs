using System.Collections.Generic;

namespace AplicacionConsultorio.Models
{
    public class ProfesionalXEspecialidad
    {
        public int? IdEspecialidad { get; set; }

        public int IdPersona { get; set; }
        public string Matricula_profesional { get; set; }

        public string? Detalles { get; set; }

        public List<Agenda> Agenda { get; set; }
        public List<Turno> Turno { get; set; }
    }
}
