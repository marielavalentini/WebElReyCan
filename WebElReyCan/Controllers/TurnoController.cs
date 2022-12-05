using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebElReyCan.Data;
using WebElReyCan.Models;

namespace WebElReyCan.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnoContext _context;

        public TurnoController(TurnoContext context)
        {
            _context = context;
        }
        // GET: Auto
        public ActionResult Index()
        {

            return View("Index",_context.Turnos.ToList());
        }

         public ActionResult Create()
        {
            Turno turno = new Turno();
            return View("Create", turno);

        }

        [HttpPost]

        public ActionResult Create(Turno turno)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", turno);
            }
            else
            {
                _context.Turnos.Add(turno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [ActionName("Detalle")]
        public ActionResult Detalle(int id)
        {
            Turno turno = _context.Turnos.Find(id);

            if (turno != null)
            {
                return View("Detalle", turno);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/turno/Modificar/{TurnoId}")]

        public ActionResult Modificar(int id)
        {
            Turno turno = _context.Turnos.Find(id);

            if (turno == null)
            {
                return NotFound();
            }
            else
            {
                return View("Modificar", turno);
            }
        }

        [HttpPost]

        public ActionResult Modificar(Turno turno)
        {
            if (!ModelState.IsValid)
            {
                return View("Modificar", turno);
            }
            else
            {
                _context.Entry(turno).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", turno);
            }
        }

        [HttpGet("/turno/ListarPorFecha/{Fecha}")]
        
        public ActionResult ListarPorFecha(DateTime fecha)
        {
            List<Turno> turnos = (from t in _context.Turnos
                                where t.Fecha == fecha
                                select t).ToList();

            return View("Index", turnos);
        }

        [HttpGet]

        //GET: turno/delete/id

        public ActionResult Delete(int id)
        {
            Turno turno = _context.Turnos.Find(id);

            if (turno == null)
            {
                return NotFound();

            }
            return View("Delete", turno);
        }

        [HttpPost]
        [ActionName("Delete")]

        //POST: /turno/Delete

        public ActionResult DeleteConfirmed(int id)
        {
            Turno turno = _context.Turnos.Find(id);

            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

