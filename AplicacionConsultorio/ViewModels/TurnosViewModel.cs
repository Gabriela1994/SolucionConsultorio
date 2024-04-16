using AplicacionConsultorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AplicacionConsultorio.ViewModels
{
    public class TurnosViewModel
    {
        public class ListaDeTurnos
        {
            public int ID { get; set; }
            [Display(Name = "Nombre Profesional")]
            public string Nombre_profesional { get; set; }
            [Display(Name = "Apellido Profesional")]
            public string Apellido_profesional { get; set; }
            public string Especialidad { get; set; }
            [Display(Name = "Nombre paciente")]
            public string Nombre_paciente { get; set; }
            [Display(Name = "Apellido paciente")]
            public string Apellido_paciente { get; set; }
            [Display(Name = "Dni")]
            public int? Dni_paciente { get; set; }
            [Display(Name = "Tipo de consulta")]
            public string Tipo_consulta { get; set; }
            [Display(Name = "Estado del turno")]
            public string Estado_turno { get; set; }
            [Display(Name = "Fecha")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime Fecha_consulta { get; set; }
            public string Horario { get; set; }
            public string Notas { get; set; }

            public ListaDeTurnos()
            {

            }

            public string ObtenerDescripcionTurno()
            {
                return $"Turno para {Nombre_profesional} - {Nombre_paciente} el {Fecha_consulta.ToShortDateString()} a las {Horario}";
            }

        }

        public class CrearUnTurno
        {
            public int ID { get; set; }

            public ProfesionalXEspecialidad Profesional { get; set; }
            public Tipo_consulta TipoConsulta { get; set; }
            public Estado_turno EstadoTurno { get; set; }
            public Horario Horarios { get; set; }

            [Display(Name = "Nombre Profesional")]
            public string Nombre_profesional { get; set; }

            [Display(Name = "Apellido Profesional")]
            public string Apellido_profesional { get; set; }
            public string Especialidad { get; set; }
            public PacienteXObraSocial Paciente { get; set; }
            [Display(Name = "Nombre paciente")]
            public string Nombre_paciente { get; set; }
            [Display(Name = "Apellido paciente")]
            public string Apellido_paciente { get; set; }
            [Display(Name = "Dni")]
            public int Dni_paciente { get; set; }
            [Display(Name = "Tipo de consulta")]
            public string Tipo_consulta { get; set; }
            [Display(Name = "Estado del turno")]
            public string Estado_turno { get; set; }
            [Display(Name = "Fecha")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime Fecha_consulta { get; set; }
            public string Horario { get; set; }



            public CrearUnTurno()
            {

            }
        }

        public class ProfesionalesTurno
        {
            public int ID { get; set; }
            public ProfesionalXEspecialidad Profesional { get; set; }
            [Display(Name = "Nombre Profesional")]
            public string Nombre_profesional { get; set; }
            [Display(Name = "Apellido Profesional")]
            public string Apellido_profesional { get; set; }

            public string NombreCompletoProfesional()
            {
                return $"{Apellido_profesional} {Nombre_profesional}";
            }

        }
    }
}
