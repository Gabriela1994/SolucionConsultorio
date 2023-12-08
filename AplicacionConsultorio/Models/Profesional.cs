using System.ComponentModel.DataAnnotations;
using System;

namespace AplicacionConsultorio.Models
{
    public class Profesional
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [Display(Name = "Segundo nombre")]
        public string? Nombre_secundario { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_nacimiento { get; set; }
        public int? Telefono { get; set; }
        public int? Celular { get; set; }

        [EmailAddress(ErrorMessage = "Correo electronico invalido")]
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        public Genero Genero { get; set; }

        public Especialidad Especialidad { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime? fecha_registro { get; set; }
    }
}
