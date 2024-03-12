using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AplicacionConsultorio.Models
{
    public class Agenda
    {
        public int ID { get; set; }
        public ProfesionalXEspecialidad Profesional { get; set; } //modifique esto, la relacion cambia de persona a profesional

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

    }
}
