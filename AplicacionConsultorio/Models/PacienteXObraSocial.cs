using System.Collections.Generic;

namespace AplicacionConsultorio.Models
{
    
    public class PacienteXObraSocial
    {

        public int? IdObraSocial{ get; set; }
        
        public int IdPersona { get; set; }

        public string Detalles { get; set; }
        public List<Turno> Turno { get; set; }

    }
    
}
