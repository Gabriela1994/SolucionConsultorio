using System.ComponentModel.DataAnnotations;
using System;

namespace AplicacionConsultorio.Models
{
    public class Profesional
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public Especialidad Especialidad { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime? fecha_registro { get; set; }
    }
}
