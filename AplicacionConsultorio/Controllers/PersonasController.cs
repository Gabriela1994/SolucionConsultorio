using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Data;
using System.Linq;

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
            return View();
        }

        // POST: PersonasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
