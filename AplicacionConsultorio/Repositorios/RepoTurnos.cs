﻿using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static AplicacionConsultorio.ViewModels.TurnosViewModel;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoTurnos
    {
        private readonly ConsultorioContext _context;

        public RepoTurnos(ConsultorioContext context)
        {
            _context = context;
        }

        public List<ListaDeTurnos> ObtenerDatosTurno()
        {
            List<ListaDeTurnos> lista_turnos = new List<ListaDeTurnos>();

                lista_turnos = (from turno in _context.Turno
                                join pa in _context.PacienteXObraSocial on turno.Paciente.IdPersona equals pa.IdPersona
                                join pro in _context.ProfesionalXEspecialidad on turno.Profesional.IdPersona equals pro.IdPersona
                                join pacientes in _context.Persona on pa.IdPersona equals pacientes.ID
                                join profesionales in _context.Persona on pro.IdPersona equals profesionales.ID
                                join especialidad in _context.Especialidad on pro.IdEspecialidad equals especialidad.ID
                                join estado in _context.EstadoTurno on turno.Estado_turno.ID equals estado.ID
                                join tipo in _context.Tipo_consulta on turno.Tipo_consulta.ID equals tipo.ID
                                select new ListaDeTurnos
                                {
                                    Fecha_consulta = turno.Fecha_consulta,
                                    Horario = turno.Horario,
                                    Nombre_profesional = profesionales.Nombre,
                                    Apellido_profesional = profesionales.Apellido,
                                    Especialidad = especialidad.Nombre,
                                    Nombre_paciente = pacientes.Nombre,
                                    Apellido_paciente = pacientes.Apellido,
                                    Dni_paciente = pacientes.Dni,
                                    Estado_turno = estado.Nombre,
                                    Tipo_consulta = tipo.Nombre                                  
                                }).ToList();

            return lista_turnos;
        }

        public void CrearUnTurno(CrearUnTurno data)
        {

            using (_context)
            {
                Turno turno = new Turno
                {
                    Paciente = data.Paciente,
                    Profesional = data.Profesional,
                    //Horario = data.Horario,
                    Tipo_consulta = data.TipoConsulta,
                    Estado_turno = data.EstadoTurno,
                    Fecha_consulta = data.Fecha_consulta
                };

                _context.Turno.Add(turno);
                _context.SaveChanges();

            }
        }

        public void BuscarTurnoPorProfesional(int id_profesional, DateTime fecha)
        {

        }

        public bool FechaDisponible(DateTime fechaConsulta)
        {
            var turnosExistentes = ObtenerDatosTurno();
            // Verificar si existe algún turno para la fecha de consulta
            bool fechaDisponible = !turnosExistentes.Any(turno => turno.Fecha_consulta.Date == fechaConsulta.Date);
            return fechaDisponible;
        }        
        //public bool HorarioDisponible(TimeOnly horario)
        //{
        //    var turnosExistentes = ObtenerDatosTurno();
        //    // Verificar si existe algún turno con el mismo horario
        //    bool horarioDisponible = !turnosExistentes.Any(turno => turno.Horario == horario);
        //    return horarioDisponible;
        //}
    }
}
