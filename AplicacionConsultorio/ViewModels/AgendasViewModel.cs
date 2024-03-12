using AplicacionConsultorio.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection.Metadata;

namespace AplicacionConsultorio.ViewModels
{
    public class AgendasViewModel
    {
        public class ListaDeAgendas
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            [Display(Name = "Fecha de inicio")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaInicio { get; set; }

            [Display(Name = "Fecha de final")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaFinal { get; set; }

            [Display(Name = "Hora de llegada")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_llegada { get; set; }

            [Display(Name = "Hora de salida")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_salida { get; set; }

            [Display(Name = "Duracion de la consulta")]
            public string Duracion_consulta { get; set; }
            public int Id_profesional { get; set; }
        }        
        
        
        public class ListaDeAgendasPorProfesional
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Especialidad { get; set; }

            [Display(Name = "Fecha de inicio")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaInicio { get; set; }

            [Display(Name = "Fecha de final")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaFinal { get; set; }

            [Display(Name = "Hora de llegada")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_llegada { get; set; }

            [Display(Name = "Hora de salida")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_salida { get; set; }

            //[Display(Name = "Día")]
            public string Dia_semana { get; set; } //Probar esta relacion n:1

            [Display(Name = "Duracion de la consulta")]
            public string Duracion_consulta { get; set; }
        }

        public class CrearAgenda
        {
            public int IdProfesional { get; set; }

            [Display(Name = "Fecha de inicio")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaInicio { get; set; }

            [Display(Name = "Fecha de final")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime FechaFinal { get; set; }

            [Display(Name = "Hora de llegada")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_llegada { get; set; }

            [Display(Name = "Hora de salida")]
            [DataType(DataType.Time)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
            public TimeSpan Hora_salida { get; set; }

            public string Duracion_consulta { get; set; }
        }
        public class ProfesionalDatos
        {
            public string Nombre { get; set; }            
            public string Apellido { get; set; }
            public string Especialidad { get; set; }
            public string Nombre_completo { get; set; }

            public ProfesionalDatos(string nombre, string apellido)
            {
                Nombre_completo = nombre + apellido;
            }
        }
    }
}
