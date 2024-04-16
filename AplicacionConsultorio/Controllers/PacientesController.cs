using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using static AplicacionConsultorio.ViewModels.PacientesViewModel;
using AplicacionConsultorio.Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AplicacionConsultorio.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ConsultorioContext _context;

        public PacientesController(ConsultorioContext context)
        {
            _context = context;
        }
        // GET: PacientesController
        public ActionResult Index()
        {
            RepoPacientes pacientes = new RepoPacientes(_context);
            return View(pacientes.ObtenerListaDePacientes());
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            RepoObraSociales obras_sociales = new RepoObraSociales(_context);
            var lista_obrasSociales = obras_sociales.ListaDeObrasSociales();

            RepoGeneros generos = new RepoGeneros(_context);
            var lista_generos = generos.ListaDeGeneros();

            RepoRoles roles = new RepoRoles(_context);
            var lista_roles = roles.ListaDeRoles();

            ViewBag.Genero = lista_generos;
            ViewBag.Roles = lista_roles;
            ViewBag.ObraSocial = lista_obrasSociales;

            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgregarPersona persona, AgregarPaciente paciente, string Genero, string ObraSocial)
        {
            var transaction = _context.Database.BeginTransaction();
            const string rol_profesional = "2";

            try
            {
                if (ModelState.IsValid)
                {
                    transaction.CreateSavepoint("SeDevuelve");
                    RepoPersonas repoPersona = new RepoPersonas(_context);
                    persona.Genero = repoPersona.DevuelvoGenero(Genero);

                    persona.Rol = repoPersona.DevuelvoRol(rol_profesional);
                    var id_persona = repoPersona.CreoPersonaYDevuelvoID(persona);
                    //
                    var id_obraSocial = Int32.Parse(ObraSocial);
                    paciente.Id_ObraSocial = id_obraSocial;

                    RepoPacientes repoPacientes = new RepoPacientes(_context);
                    repoPacientes.CrearPaciente(paciente, id_persona);

                    transaction.Commit();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                transaction.RollbackToSavepoint("SeDevuelve");
                return View();
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
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

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
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
        [HttpGet]
        public ActionResult EncontrarPaciente(int dni)
        {
                var dni_parse = Convert.ToString(dni);

                if (dni_parse.Length >= 8)
                {
                    PacientesServicio servicio_paciente = new PacientesServicio(_context);
                    var paciente_encontrado = servicio_paciente.EncontrarPaciente(dni);

                    if (paciente_encontrado != null)
                    {

                        ViewData["Nombre"] = paciente_encontrado.Nombre;
                        ViewData["Apellido"] = paciente_encontrado.Apellido;
                        ViewData["Dni"] = paciente_encontrado.Dni;
                        return PartialView("_Paciente", paciente_encontrado);
                    }
                }
                else
                {
                    return PartialView("_ErrorNumerico", null);
                }

            return PartialView("_ErrorRegistro", null);
        }
    }
}
