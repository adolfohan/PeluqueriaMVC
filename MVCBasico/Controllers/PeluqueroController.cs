using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;

namespace MVCBasico.Controllers
{
    public class PeluqueroController : Controller
    {
        private readonly PeluqueriaDatabaseContext _context;

        public PeluqueroController(PeluqueriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Peluquero
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peluqueros.ToListAsync());
        }

        // GET: Peluquero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluquero = await _context.Peluqueros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peluquero == null)
            {
                return NotFound();
            }

            return View(peluquero);
        }

        // GET: Peluquero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peluquero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Servicio,Id,Nombre,Apellido,Dni,Telefono")] Peluquero peluquero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peluquero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peluquero);
        }

        // GET: Peluquero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluquero = await _context.Peluqueros.FindAsync(id);
            if (peluquero == null)
            {
                return NotFound();
            }
            return View(peluquero);
        }

        // POST: Peluquero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Servicio,Id,Nombre,Apellido,Dni,Telefono")] Peluquero peluquero)
        {
            if (id != peluquero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peluquero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeluqueroExists(peluquero.Id))
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
            return View(peluquero);
        }

        // GET: Peluquero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluquero = await _context.Peluqueros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peluquero == null)
            {
                return NotFound();
            }

            return View(peluquero);
        }

        // POST: Peluquero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peluquero = await _context.Peluqueros.FindAsync(id);
            _context.Peluqueros.Remove(peluquero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeluqueroExists(int id)
        {
            return _context.Peluqueros.Any(e => e.Id == id);
        }
    }
}
