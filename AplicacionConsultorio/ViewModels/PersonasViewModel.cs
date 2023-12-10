using AplicacionConsultorio.Models;
using System.ComponentModel.DataAnnotations;

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
    }
}
