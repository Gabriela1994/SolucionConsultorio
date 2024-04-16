using AplicacionConsultorio.Data;
using AplicacionConsultorio.Repositorios;
using AplicacionConsultorio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static AplicacionConsultorio.ViewModels.AgendasViewModel;
using static AplicacionConsultorio.ViewModels.ProfesionalesViewModel;

namespace AplicacionConsultorio.Controllers
{
    public class AgendasController : Controller
    {
        private readonly ConsultorioContext _context;

        public AgendasController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: AgendasController
        public ActionResult Index()
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            return View(repoAgendas.ListaDeAgendas());
        }

        // GET: AgendasController/Details/5
        public ActionResult Details(int id)
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            var data_agenda = repoAgendas.ListaDeAgendaPorProfesional2(id);

            foreach(var items in data_agenda)
            {
                ViewBag.Nombre = items.Nombre;
                ViewBag.Apellido = items.Apellido;
                ViewBag.Especialidad = items.Especialidad;
            }

            return View(data_agenda);
        }

        [HttpGet]
        public IActionResult FechasDeProfesionales(int idProfesional)
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            var fechas_profesionales = repoAgendas.ListaHorariosDelProfesionalEnLaAgenda(idProfesional);

            ViewBag.FechaInicio = fechas_profesionales.Fecha_inicial;
            ViewBag.FechaLimite = fechas_profesionales.Fecha_final;

            return PartialView("_FechasAgenda", fechas_profesionales);
        }

        // GET: AgendasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrearAgenda value)
        {
            try
            {
                RepoAgendas repoAgendas = new RepoAgendas(_context);
                RepoProfesionales repoProfesionales= new RepoProfesionales(_context);
                var profesional = repoProfesionales.DevuelvoProfesional(value.IdProfesional);

                repoAgendas.CrearAgenda(value, profesional);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendasController/Edit/5
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

        // GET: AgendasController/Delete/5
        public ActionResult Delete(int id)
        {
            RepoAgendas repoAgendas = new RepoAgendas(_context);
            repoAgendas.EliminarAgenda(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: AgendasController/Delete/5
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
