using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_ll.Data;
using Examen_ll.Models;
using thcp2.Common;

namespace Examen_ll.Controllers
{
    public class TareasController : Controller
    {
        private readonly int RecordsPerPage = 10;


        private readonly ApplicationDbContext _context;

        private Pagination<Tareas> paginationDepartaments;
        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            return View(await _context.Tareas.ToListAsync());
        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.Tarea)
                .FirstOrDefaultAsync(m => m.TareaId == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.TareaCategoria, "CategoriaId", "CategoriaNombre");
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TareaId,FechaDeInicio,FechaFinal,Titulo,Descripcion,CategoriaId")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tareas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.TareaCategoria, "CategoriaId", "CategoriaNombre", tareas.CategoriaId);
            return View(tareas);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas.FindAsync(id);
            if (tareas == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.TareaCategoria, "CategoriaId", "CategoriaNombre", tareas.CategoriaId);
            return View(tareas);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TareaId,FechaDeInicio,FechaFinal,Titulo,Descripcion,CategoriaId")] Tareas tareas)
        {
            if (id != tareas.TareaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tareas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareasExists(tareas.TareaId))
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
            ViewData["CategoriaId"] = new SelectList(_context.TareaCategoria, "CategoriaId", "CategoriaNombre", tareas.CategoriaId);
            return View(tareas);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.Tarea)
                .FirstOrDefaultAsync(m => m.TareaId == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tareas = await _context.Tareas.FindAsync(id);
            _context.Tareas.Remove(tareas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareasExists(int id)
        {
            return _context.Tareas.Any(e => e.TareaId == id);
        }
    }
}
