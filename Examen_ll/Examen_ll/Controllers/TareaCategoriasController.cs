using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_ll.Data;
using Examen_ll.Models;

namespace Examen_ll.Controllers
{
    public class TareaCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context1;

        public TareaCategoriasController(ApplicationDbContext context)
        {
            _context1 = context;
        }

        // GET: TareaCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context1.TareaCategoria.ToListAsync());
        }

        // GET: TareaCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareaCategoria = await _context1.TareaCategoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (tareaCategoria == null)
            {
                return NotFound();
            }

            return View(tareaCategoria);
        }

        // GET: TareaCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TareaCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,CategoriaNombre")] TareaCategoria tareaCategoria)
        {
            if (ModelState.IsValid)
            {
                _context1.Add(tareaCategoria);
                await _context1.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tareaCategoria);
        }

        // GET: TareaCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareaCategoria = await _context1.TareaCategoria.FindAsync(id);
            if (tareaCategoria == null)
            {
                return NotFound();
            }
            return View(tareaCategoria);
        }

        // POST: TareaCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,CategoriaNombre")] TareaCategoria tareaCategoria)
        {
            if (id != tareaCategoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context1.Update(tareaCategoria);
                    await _context1.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaCategoriaExists(tareaCategoria.CategoriaId))
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
            return View(tareaCategoria);
        }

        // GET: TareaCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareaCategoria = await _context1.TareaCategoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (tareaCategoria == null)
            {
                return NotFound();
            }

            return View(tareaCategoria);
        }

        // POST: TareaCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tareaCategoria = await _context1.TareaCategoria.FindAsync(id);
            _context1.TareaCategoria.Remove(tareaCategoria);
            await _context1.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaCategoriaExists(int id)
        {
            return _context1.TareaCategoria.Any(e => e.CategoriaId == id);
        }
    }
}
