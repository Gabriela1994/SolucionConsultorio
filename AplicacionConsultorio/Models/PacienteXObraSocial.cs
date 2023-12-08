using AplicacionConsultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace AplicacionConsultorio.Models
{
    
    public class PacienteXObraSocial
    {

        public int? IdObraSocial{ get; set; }
        
        public int? IdPersona { get; set; }

        public string detalles { get; set; }

    }
    
}
