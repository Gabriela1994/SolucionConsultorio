﻿using System.Collections.Generic;

namespace AplicacionConsultorio.Models
{
    public class Tipo_consulta
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Turno> Turnos { get; set; }
    }
}
