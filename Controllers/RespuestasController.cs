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
    public class RespuestasController : Controller
    {
        private readonly ForoContext _context;

        public RespuestasController(ForoContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index()
        {
            var foroContext = _context.Respuestas.Include(r => r.Miembro).Include(r => r.Pregunta);
            return View(await foroContext.ToListAsync());
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Respuestas == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Miembro)
                .Include(r => r.Pregunta)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // GET: Respuestas/Create
        public IActionResult Create(int preguntaId, string titulo)
        {
            ViewData["PreguntaId"] = preguntaId;
            ViewData["Titulo"] = titulo;
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion, PreguntaId")] Respuesta respuesta)
        {
            //RespuestaId,Fecha,CantMeGustas,MiembroId,PreguntaId
            respuesta.Fecha = DateTime.Now;
            respuesta.CantMeGustas = 0;
            if (HttpContext.Session.GetInt32("_MiembroId") == null)
            {
                return Redirect("/home/customerror");
            }
            respuesta.MiembroId = (int)HttpContext.Session.GetInt32("_MiembroId");
            if (ModelState.IsValid)
            {
                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                return Redirect($"/preguntas/details/{respuesta.PreguntaId}");
            }
            //ViewData["MiembroId"] = new SelectList(_context.Miembros, "MiembroId", "MiembroId", respuesta.MiembroId);
            //ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", respuesta.PreguntaId);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Respuestas == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Miembro)
                .Include(r => r.Pregunta)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Respuestas == null)
            {
                return Problem("Entity set 'ForoContext.Respuestas'  is null.");
            }
            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuestas.Remove(respuesta);
            }
            
            await _context.SaveChangesAsync();
            return Redirect($"/preguntas/details/{respuesta.PreguntaId}");
        }

        private bool RespuestaExists(int id)
        {
          return _context.Respuestas.Any(e => e.RespuestaId == id);
        }
    }
}
