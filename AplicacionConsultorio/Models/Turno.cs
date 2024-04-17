﻿using NuGet.Packaging.Signing;
using System;

namespace AplicacionConsultorio.Models
{
    public class Turno
    {
        public int ID { get; set; }
        public ProfesionalXEspecialidad Profesional { get; set; }
        public PacienteXObraSocial Paciente { get; set; }
        public Tipo_consulta Tipo_consulta { get; set; }
        public Estado_turno Estado_turno { get; set; }
        public DateTime Fecha_consulta { get; set; }
        public TimeSpan Horario { get; set; }


    }
}
