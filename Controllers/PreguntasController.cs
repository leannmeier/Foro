using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORT_PNT1_Proyecto_2022_2C_I_Foro.Data;
using ORT_PNT1_Proyecto_2022_2C_I_Foro.Models;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Controllers
{
    public class PreguntasController : Controller
    {
        private readonly ForoContext _context;

        public PreguntasController(ForoContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var foroContext = _context.Preguntas.Include(p => p.Miembro);
            return View(await foroContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Preguntas == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.Miembro)
                .Include(p => p.Respuestas)
                .ThenInclude(r => r.Miembro)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PreguntaId == id);

            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descripcion")] Pregunta pregunta)
        {
            pregunta.Fecha = DateTime.Now;
            pregunta.CantMeGustas = 0;
            if(HttpContext.Session.GetInt32("_MiembroId") == null)
            {
                return Redirect("/home/customerror");
            }
            pregunta.MiembroId = (int)HttpContext.Session.GetInt32("_MiembroId");
            if (ModelState.IsValid)
            {
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId", pregunta.MiembroId);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Preguntas == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.Miembro)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Preguntas == null)
            {
                return Problem("Entity set 'ForoContext.Preguntas'  is null.");
            }
            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta != null)
            {
                _context.Preguntas.Remove(pregunta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntaExists(int id)
        {
          return _context.Preguntas.Any(e => e.PreguntaId == id);
        }
    }
}
