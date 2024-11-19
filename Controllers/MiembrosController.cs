﻿using System;
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
    public class MiembrosController : Controller
    {
        private readonly ForoContext _context;

        public MiembrosController(ForoContext context)
        {
            _context = context;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Miembros.ToListAsync());
        }

        // GET: Miembros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // GET: Miembros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miembros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Telefono,Rol,Nombre,Apellido,Email,Password,FechaAlta")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembro);
                await _context.SaveChangesAsync();
                return Redirect("/");
            }
            return View(miembro);
        }

        // GET: Miembros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }
            return View(miembro);
        }

        // POST: Miembros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiembroId,Telefono,Rol,Nombre,Apellido,Email,Password,FechaAlta")] Miembro miembro)
        {
            if (id != miembro.MiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembro.MiembroId))
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
            return View(miembro);
        }

        // GET: Miembros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miembros == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // POST: Miembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Miembros == null)
            {
                return Problem("Entity set 'ForoContext.Miembros'  is null.");
            }
            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro != null)
            {
                _context.Miembros.Remove(miembro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroExists(int id)
        {
          return _context.Miembros.Any(e => e.MiembroId == id);
        }
    }
}
