using AplicacionConsultorio.Data;
using AplicacionConsultorio.Repositorios;
using System;
using static AplicacionConsultorio.ViewModels.AgendasViewModel;
using static AplicacionConsultorio.ViewModels.TurnosViewModel;

namespace AplicacionConsultorio.Servicios
{
    public class AgendaServicio
    {
        private readonly ConsultorioContext _context;

        public AgendaServicio(ConsultorioContext context)
        {
            _context = context;
        }


        public void LogicaParaHorarioTurnos(CrearUnTurno turnos)
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            RepoTurnos repoTurnos = new RepoTurnos(_context);

            turnos.Horario.Hours + turnos.Horario.Minutes;
        }
    }
}
