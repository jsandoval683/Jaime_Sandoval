using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica4.Models;

namespace PruebaTecnica4.Controllers
{
    public class MateriumsController : Controller
    {
        private readonly estudiantesContext _context;

        public MateriumsController(estudiantesContext context)
        {
            _context = context;
        }

        // GET: Materiums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materia.ToListAsync());
        }

        // GET: Materiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // GET: Materiums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Materium materium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materium);
        }

        // GET: Materiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }
            return View(materium);
        }

        // POST: Materiums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Materium materium)
        {
            if (id != materium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriumExists(materium.Id))
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
            return View(materium);
        }

        // GET: Materiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // POST: Materiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materium = await _context.Materia.FindAsync(id);
            _context.Materia.Remove(materium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriumExists(int id)
        {
            return _context.Materia.Any(e => e.Id == id);
        }
    }
}
