using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoEstadoTurno
    {
        private readonly ConsultorioContext _context;

        public RepoEstadoTurno(ConsultorioContext context)
        {
            _context = context;
        }

        public Estado_turno BuscarEstadoTurno(int id)
        {
            Estado_turno estado_encontrado = new Estado_turno();

            estado_encontrado = _context.EstadoTurno.Find(id);

            return estado_encontrado;

        }
    }
}
