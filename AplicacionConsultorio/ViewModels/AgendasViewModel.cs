﻿using AplicacionConsultorio.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection.Metadata;
using NuGet.Packaging.Signing;

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

            public ListaDeAgendas(TimeSpan hora_llegada, TimeSpan hora_salida)
            {
                Hora_salida = hora_salida;
                Hora_llegada = hora_llegada;
            }
            public ListaDeAgendas()
            {

            }
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

            [Display(Name = "Duracion de la consulta")]
            public string Duracion_consulta { get; set; }

            public void FechasDisponiblesTurno()
            {
                //
            }
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

        public class FechasProfesionalPorAgenda
        {
            public int IdProfesional { get; set; }
            public DateTime Fecha_inicial { get; set; }
            public DateTime Fecha_final { get; set; }

            // Método para validar las fechas de llegada y salida
            public bool ValidarFechas()
            {
                // Se realiza una validación simple para asegurarse de que la fecha de salida sea posterior a la fecha de llegada
                return Fecha_final > Fecha_inicial;
            }
        }
    }
}
