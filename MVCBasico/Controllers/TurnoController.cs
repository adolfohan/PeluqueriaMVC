﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;
using System;
using System.Windows;

namespace MVCBasico.Controllers
{
    public class TurnoController : Controller
    {
        private readonly PeluqueriaDatabaseContext _context;

        public TurnoController(PeluqueriaDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Turno()
        {
            return View();
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
            var peluqueriaDatabaseContext = _context.Turnos.Include(t => t.Cliente).Include(t => t.Peluquero);
            return View(await peluqueriaDatabaseContext.ToListAsync());
        }

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Cliente)
                .Include(t => t.Peluquero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turno/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido");
            ViewData["PeluqueroId"] = new SelectList(_context.Peluqueros, "Id", "Apellido");
            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,PeluqueroId,Servicio,FechaInscripto")] Turno turno)
        {
            if (ModelState.IsValid && !hayTurno(turno) && fechaCorrecta(turno))
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));              
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", turno.ClienteId);
            ViewData["PeluqueroId"] = new SelectList(_context.Peluqueros, "Id", "Apellido", turno.PeluqueroId);
            return View(turno);
        }

        private bool hayTurno(Turno turnoEntrante)
        {
            foreach(var t in _context.Turnos)
            {
            if(t.FechaInscripto == turnoEntrante.FechaInscripto && t.Peluquero == turnoEntrante.Peluquero)
                {
                    return true;
                }
            }
            return false;
        }

        private bool fechaCorrecta(Turno turnoEntrante)
        {
            DateTime now = DateTime.Now;
            return turnoEntrante.FechaInscripto.CompareTo(now) >= 0;
        }


        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", turno.ClienteId);
            ViewData["PeluqueroId"] = new SelectList(_context.Peluqueros, "Id", "Apellido", turno.PeluqueroId);
            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,PeluqueroId,Servicio,FechaInscripto")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && TurnoExists(turno.Id) && fechaCorrecta(turno))
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", turno.ClienteId);
            ViewData["PeluqueroId"] = new SelectList(_context.Peluqueros, "Id", "Apellido", turno.PeluqueroId);
            return View(turno);
        } 


        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Cliente)
                .Include(t => t.Peluquero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }
    }
}