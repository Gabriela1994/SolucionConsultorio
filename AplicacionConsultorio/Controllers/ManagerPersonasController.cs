﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionConsultorio.Data;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.Repositorios;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;

namespace AplicacionConsultorio.Controllers
{
    public class ManagerPersonasController : Controller
    {
        private readonly ConsultorioContext _context;

        public ManagerPersonasController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: ManagerPersonas
        public IActionResult Index()
        {
                List<ListaDePacientes> lista_personas = new List<ListaDePacientes>();
                List<PacienteXObraSocial> lista_personas2 = new List<PacienteXObraSocial>();
            // List<Producto> lista_producto = new List<Producto>();

            using (_context)
            {
                lista_personas = (from pac in _context.PacienteXObraSocial
                                  join p in _context.Persona
                                  on pac.IdPersona equals p.ID
                                  join o in _context.ObraSocial
                                  on pac.IdObraSocial equals o.ID
                                  select new ListaDePacientes
                                  {
                                      Nombre = p.Nombre,
                                      Apellido = p.Apellido,
                                      Dni = p.Dni,
                                      Genero = p.Genero.Nombre,
                                      Obra_Social = o.Nombre,

                                  }
                                  ).ToList();


            }

            //    lista_productos = (from p in bd.Producto
            //                           join c in bd.Categoria
            //                           on p.id_categoria equals c.id_categoria
            //                           select p).ToList();
            //}

            // formula para join:





            //RepoPacientes pacientes = new RepoPacientes(_context);
            return View(lista_personas2);
        }

        // GET: ManagerPersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: ManagerPersonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagerPersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Nombre_secundario,Apellido,Dni,Fecha_nacimiento,Id_cobertura,Telefono,Celular,Correo,Direccion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: ManagerPersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: ManagerPersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Nombre_secundario,Apellido,Dni,Fecha_nacimiento,Id_cobertura,Telefono,Celular,Correo,Direccion")] Persona persona)
        {
            if (id != persona.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: ManagerPersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: ManagerPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persona == null)
            {
                return Problem("Entity set 'ConsultorioContext.Persona'  is null.");
            }
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
          return (_context.Persona?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
