using AplicacionConsultorio.Data;
using System.Collections.Generic;
using AplicacionConsultorio.Models;
using AplicacionConsultorio.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static AplicacionConsultorio.Controllers.ManagerPersonasController;
using static AplicacionConsultorio.ViewModels.PersonasViewModel;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicacionConsultorio.Repositorios
{
    public class RepoPersonas
    {
        private readonly ConsultorioContext _context;

        public RepoPersonas(ConsultorioContext context)
        {
            _context = context;
        }
        public Genero ObtenerGeneros(int id_genero)
        {
            return _context.Genero.Select(g => new Genero()
            {
                ID = g.ID,
                Nombre = g.Nombre,
            }).Where(g => g.ID == id_genero).FirstOrDefault();
        }

        public void CrearPersona(AgregarPersona value)
        {
            Persona persona = new Persona();
            /*
            Genero genero = (from g in _context.Genero
                             where g.ID == id_genero
                             select g).FirstOrDefault();            
            
            Roles rol = (from r in _context.Roles
                             where r.ID == id_rol
                             select r).FirstOrDefault();

           */

            using (_context)
            {
                Persona persona2 = new Persona {
                    Nombre = value.Nombre,
                    Nombre_secundario = value.Nombre_secundario,
                    Apellido = value.Apellido,
                    Dni = value.Dni,
                    Fecha_nacimiento = value.Fecha_nacimiento,
                    Telefono = value.Telefono,
                    Celular = value.Celular,
                    Correo = value.Correo,
                    Direccion = value.Direccion,
                    Genero = value.Genero
                    //Rol = rol
                };
                
                _context.Persona.Add(persona2);                //persona2.Genero.ID = genero;
                _context.SaveChanges();

            }

            }
        }
    }
