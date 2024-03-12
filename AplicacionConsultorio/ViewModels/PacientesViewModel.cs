using AplicacionConsultorio.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionConsultorio.ViewModels
{
    public class PacientesViewModel
    {
        public class AgregarPaciente
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
            public string? Telefono { get; set; }
            public string? Celular { get; set; }

            [EmailAddress(ErrorMessage = "Correo electrónico invalido")]
            public string? Correo { get; set; }
            public string? Direccion { get; set; }
            public Genero? Genero { get; set; }
            public Roles? Rol { get; set; }

            [Display(Name = "Obra social")]
            public  int? Id_ObraSocial { get; set; }
            public string Detalles { get; set; }
        }

        public class PacientePorDni
        {
            public string? Nombre { get; set; }

            [Display(Name = "Segundo nombre")]
            public string? Nombre_secundario { get; set; }
            public string? Apellido { get; set; }
            public int? Dni { get; set; }

            public PacientePorDni()
            {

            }
            public PacientePorDni(int dni)
            {
                Dni = dni;
            }
        }
    }
}