using AplicacionConsultorio.Data;
using AplicacionConsultorio.Repositorios;
using static AplicacionConsultorio.ViewModels.TurnosViewModel;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AplicacionConsultorio.Servicios
{
    public class TurnosServicio
    {
        private readonly ConsultorioContext _context;

        public TurnosServicio(ConsultorioContext context)
        {
            _context = context;
        }


        public void CrearTurno(CrearUnTurno values, string Profesionales, string Horarios, string TipoConsulta)
        {
            RepoPacientes repoPacientes = new RepoPacientes(_context);
            var paciente_dni = values.Dni_paciente;
            var paciente_encontrado = repoPacientes.BuscarPacientePorDni2(paciente_dni);

            values.Paciente = paciente_encontrado;

            //_--------paciente listo
            var id_profesional = Convert.ToInt32(Profesionales);
            RepoProfesionales repoProfesionales = new RepoProfesionales(_context);
            var profesional = repoProfesionales.DevuelvoProfesional(id_profesional);
            values.Profesional = profesional;
            //_--------profesional listo

            var id_horario = Convert.ToInt32(Horarios);
            RepoHorarios repoHorarios = new RepoHorarios(_context);
            var horario = repoHorarios.BuscarHorarioPorId(id_horario);
            values.Horarios = horario;
            //_-------horario listo

            var tipoConsulta = Convert.ToInt32(TipoConsulta);
            RepoTipoConsulta repoTipoConsulta = new RepoTipoConsulta(_context);
            var tipo = repoTipoConsulta.BuscarTipoConsultaPorId(tipoConsulta);
            values.TipoConsulta = tipo;
            //_-------tipo de consulta listo

            const int estado_turno = 1;

            RepoEstadoTurno repoEstadoTurno = new RepoEstadoTurno(_context);
            var estado = repoEstadoTurno.BuscarEstadoTurno(estado_turno);
            values.EstadoTurno = estado;
            //_-------estado del turno listo

            RepoTurnos repo_turnos = new RepoTurnos(_context);
            repo_turnos.CrearUnTurno(values);
        }
    }
}

