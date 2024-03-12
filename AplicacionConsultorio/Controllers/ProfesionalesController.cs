using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using static AplicacionConsultorio.ViewModels.ProfesionalesViewModel;
using static AplicacionConsultorio.Controllers.PersonasController;

namespace AplicacionConsultorio.Controllers
{
    public class ProfesionalesController : Controller
    {

        private readonly ConsultorioContext _context;

        public ProfesionalesController(ConsultorioContext context)
        {
            _context = context;
        }
        // GET: ProfesionalesController
        public ActionResult Index()
        {
            RepoProfesionales profesionales = new RepoProfesionales(_context);
            return View(profesionales.ObtenerListaDeProfesionales());
        }

        // GET: ProfesionalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfesionalesController/Create
        public ActionResult Create()
        {
            RepoEspecialidades especialidades = new RepoEspecialidades(_context);
            var lista_especialidades = especialidades.ListaDeEspecialidades();

            RepoGeneros generos = new RepoGeneros(_context);
            var lista_generos = generos.ListaDeGeneros();

            RepoRoles roles = new RepoRoles(_context);
            var lista_roles = roles.ListaDeRoles();

            ViewBag.Genero = lista_generos;
            ViewBag.Roles = lista_roles;
            ViewBag.Especialidad = lista_especialidades;

            return View();
        }

        // POST: ProfesionalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgregarPersona persona, AgregarProfesional profesional, string Especialidad, string Genero)
        {
            using var transaction = _context.Database.BeginTransaction();
            const string rol_profesional = "1";
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
                    var id_especialidad = Int32.Parse(Especialidad);
                    profesional.IdEspecialidad = id_especialidad; 

                    RepoProfesionales repo_profesional = new RepoProfesionales(_context);
                    repo_profesional.CrearProfesional(profesional, id_persona, rol_profesional);

                    transaction.Commit();
                    return RedirectToAction(nameof(Index));
                }
                return View("Error");
            }
            catch(Exception e)
            {
                transaction.RollbackToSavepoint("SeDevuelve");
                return View("Error");
                throw new Exception("Ingresaste un dato incorrecto");
            }
        }

        // GET: ProfesionalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfesionalesController/Edit/5
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

        // GET: ProfesionalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesionalesController/Delete/5
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
