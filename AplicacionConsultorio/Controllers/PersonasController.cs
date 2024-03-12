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
using NuGet.Protocol;

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
            RepoPersonas personas = new RepoPersonas(_context);
            return View(personas.ObtenerListaDePersonas());
        }

        // GET: PersonasController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController1/Create
        public ActionResult Create()
        {
            //ViewBag.GeneroId = new SelectList(_context.Genero, "ID", "Nombre");
            //ViewBag.RolID = new SelectList(_context.Roles, "ID", "Nombre");

            RepoGeneros generos = new RepoGeneros(_context);
            var lista_generos = generos.ListaDeGeneros();
            
            RepoRoles roles = new RepoRoles(_context);
            var lista_roles = roles.ListaDeRoles();

            ViewBag.Genero = lista_generos;
            ViewBag.Roles = lista_roles;

            return View();
        }

        // POST: PersonasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgregarPersona persona, string Genero, string Roles)
        {
            if (ModelState.IsValid)
            {
                RepoPersonas repoPersonas = new RepoPersonas(_context);

                var id_genero = Int32.Parse(Genero);
                var genero = _context.Genero.FirstOrDefault(g => g.ID == id_genero);         //hay que mejorar esto    
            
                var id_rol = Int32.Parse(Roles);
                var rol = _context.Roles.FirstOrDefault(r => r.ID == id_rol);               //hay que mejorar esto

                persona.Genero = genero;
                persona.Rol = rol;

                repoPersonas.CrearPersona(persona);
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PersonasController1/Edit/5
        public ActionResult Edit(int Id)
        {
            RepoPersonas repoPersonas = new RepoPersonas(_context);
            var persona = repoPersonas.ObtenerPersona(Id);
            if (persona == null)
            {
                return View();
            }

            RepoGeneros generos = new RepoGeneros(_context);
            var lista_generos = generos.ListaDeGeneros();

            RepoRoles roles = new RepoRoles(_context);
            var lista_roles = roles.ListaDeRoles();

            var fecha = repoPersonas.FechaFormateada(Id);

            ViewBag.Persona = persona;
            ViewBag.Genero = lista_generos;
            ViewBag.Roles = lista_roles;
            ViewBag.Fecha = fecha;

            return View();
        }

        // POST: PersonasController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgregarPersona persona, string Genero, String Roles)
        {
            try
            {
                RepoPersonas repoPersonas = new RepoPersonas(_context);

                if (Genero != null)
                {
                    persona.Genero = repoPersonas.DevuelvoGenero(Genero);
                }
                persona.Genero = repoPersonas.ObtenerPersonaYDevolverGenero(id);

                if (Roles != null)
                {
                    persona.Rol = repoPersonas.DevuelvoRol(Roles);
                }
                persona.Rol = repoPersonas.ObtenerPersonaYDevolverRol(id);


                repoPersonas.EditarPersona(persona, id);
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
            //RepoPersonas repoPersonas = new RepoPersonas(_context);
            //repoPersonas.EliminarPersona(id);
            return View("Index");
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
