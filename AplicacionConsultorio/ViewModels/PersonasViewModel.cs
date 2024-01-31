using AplicacionConsultorio.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AplicacionConsultorio.ViewModels
{
    public class PersonasViewModel
    {

        public class ListaDePacientes
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }
            public int? Dni { get; set; }
            public string Genero { get; set; }

            [Display(Name = "Obra social")]
            public string Obra_Social { get; set; }

        }

        public class AgregarPersona
        {
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

            public int IdGenero { get; set; }

            public Genero? Genero { get; set; }
            public Roles? Rol { get; set; }
        }
    }
}
