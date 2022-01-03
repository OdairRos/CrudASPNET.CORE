using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudASPNEW.CORE.Data;
using CrudASPNEW.CORE.Models;

namespace CrudASPNEW.CORE.Controllers
{
    public class DepasController : Controller
    {
        private readonly CrudASPNETCOREContext _context;

        public DepasController(CrudASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Depas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Depa.ToListAsync());
        }

        // GET: Depas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depa = await _context.Depa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depa == null)
            {
                return NotFound();
            }

            return View(depa);
        }

        // GET: Depas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Depa depa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depa);
        }

        // GET: Depas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depa = await _context.Depa.FindAsync(id);
            if (depa == null)
            {
                return NotFound();
            }
            return View(depa);
        }

        // POST: Depas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Depa depa)
        {
            if (id != depa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepaExists(depa.Id))
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
            return View(depa);
        }

        // GET: Depas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depa = await _context.Depa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depa == null)
            {
                return NotFound();
            }

            return View(depa);
        }

        // POST: Depas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depa = await _context.Depa.FindAsync(id);
            _context.Depa.Remove(depa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepaExists(int id)
        {
            return _context.Depa.Any(e => e.Id == id);
        }
    }
}
