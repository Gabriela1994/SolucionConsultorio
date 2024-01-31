using System.Collections.Generic;

namespace AplicacionConsultorio.Models
{
    public class Genero
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Persona> Personas { get; set; }
    }
}
