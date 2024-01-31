using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Data;
using System.Linq;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicacionConsultorio.Repositorios;
using System;
using Newtonsoft.Json.Linq;

namespace AplicacionConsultorio.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ConsultorioContext _context;

        public PersonasController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: PersonasController1
        public IActionResult Index()
        {
            List<Persona> lista_personas = new List<Persona>();
            Persona persona = new Persona();
            using (_context)
            {
                lista_personas = _context.Persona.ToList();
            }
            return View(lista_personas);
        }

        // GET: PersonasController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController1/Create
        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(_context.Genero, "ID", "Nombre");
            ViewBag.RolID = new SelectList(_context.Roles, "ID", "Nombre");

            return View();
        }

        // POST: PersonasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgregarPersona persona)
        {
            //ViewBag.Genero = new SelectList(_context.Genero, "ID", "Nombre", persona.Genero);

            //ViewBag.Rol = new SelectList(_context.Roles, "ID", "Nombre", persona.Rol);
            RepoPersonas repoPersonas = new RepoPersonas(_context);

            var prueba_rol = new SelectList(_context.Roles, "ID", "Nombre", persona.Rol);
            var prueba_genero = new SelectList(_context.Genero, "ID", "Nombre", persona.Genero);

            int id_genero = 0;
            int id_rol = 0;

            /*
            foreach(var rol in prueba_rol)
            {
                id_rol = Convert.ToInt32(rol.Value);
            }         
            
            foreach (var generos in prueba_genero)
            {
                id_genero = Convert.ToInt32(generos.Value);                
            }
            */

            repoPersonas.CrearPersona(persona);

            return RedirectToAction(nameof(Index));
            /*
                var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
                return View(persona);
            */
        }

        // GET: PersonasController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController1/Edit/5
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

        // GET: PersonasController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController1/Delete/5
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
