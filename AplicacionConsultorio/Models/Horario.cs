using System.Collections.Generic;

namespace AplicacionConsultorio.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public string Hora { get; set; }

        public List<Turno> Turnos { get; set; }
    }
}
