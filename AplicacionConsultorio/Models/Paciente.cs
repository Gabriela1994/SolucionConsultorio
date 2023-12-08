using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacionConsultorio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        
        public Persona Persona { get; set; }

        [Display(Name = "Obra social")]
        public ObraSocial ObraSocial { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime? fecha_registro { get; set; }
    }
}
