using AplicacionConsultorio.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionConsultorio.ViewModels
{
    public class ProfesionalesViewModel
    {
        public class AgregarProfesional
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
            public string? Telefono { get; set; }
            public string? Celular { get; set; }

            [EmailAddress(ErrorMessage = "Correo electronico invalido")]
            public string? Correo { get; set; }
            public string? Direccion { get; set; }
            public Genero? Genero { get; set; }
            public Roles? Rol { get; set; }

            [Display(Name = "Especialidad")]
            public int? IdEspecialidad { get; set; }
            public string Matricula_profesional { get; set; }

            public int? IdPersona { get; set; }

            public string? Detalles { get; set; }
        }
    }
}
