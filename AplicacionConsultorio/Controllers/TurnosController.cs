using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Repositorios;
using AplicacionConsultorio.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static AplicacionConsultorio.ViewModels.TurnosViewModel;

namespace AplicacionConsultorio.Controllers
{
    public class TurnosController : Controller
    {
        private readonly ConsultorioContext _context;

        public TurnosController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: TurnosController
        public ActionResult Index()
        {
            RepoTurnos repoTurnos = new RepoTurnos(_context);
            return View(repoTurnos.ObtenerDatosTurno());
        }

        // GET: TurnosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TurnosController/Create
        public ActionResult Create()
        
        {
            RepoEspecialidades especialidades = new RepoEspecialidades(_context);
            var lista_especialidades = especialidades.ListaDeEspecialidades2();

            RepoTipoConsulta tipo_consulta = new RepoTipoConsulta(_context);
            var lista_tipos = tipo_consulta.ListarTiposDeConsulta();

            ViewBag.Especialidades = lista_especialidades;
            ViewBag.TipoConsulta = lista_tipos;

            return View();
            }

        //aqui obtengo datos de las agendas de profesionales con profesionales

        [HttpGet]
        public IActionResult Profesionales(int especialidadId)
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            var profesionales = repoAgendas.ListaDeProfesionalesConAgenda(especialidadId);

            ViewBag.Profesionales = new SelectList(profesionales, "Value", "Text");

            return PartialView("_Profesionales", profesionales);
        }

        // POST: TurnosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrearUnTurno values, string Profesionales, string Horarios, string TipoConsulta)
        {
            try
            {
                values.Especialidad = "1";
                values.TipoConsulta = null;

                RepoTurnos repoTurnos = new RepoTurnos(_context);
                bool esta_disponible = repoTurnos.FechaDisponible(values.Fecha_consulta);


                AgendaServicio servicio = new AgendaServicio(_context);
                servicio.LogicaParaHorarioTurnos(values);

                if (esta_disponible == true)
                {
                    TurnosServicio servicio_turnos = new TurnosServicio(_context);
                    servicio_turnos.CrearTurno(values, Profesionales, Horarios, TipoConsulta);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: TurnosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TurnosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurnosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TurnosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
