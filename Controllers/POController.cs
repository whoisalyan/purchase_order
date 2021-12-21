#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurcaseOrder.Data;
using PurcaseOrder.Models;

namespace PurcaseOrder.Controllers
{
    public class POController : Controller
    {
        private readonly ApplicationDbContext _context;

        public POController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PO
        public async Task<IActionResult> Index()
        {
            return View(await _context.PO.ToListAsync());
        }

        // GET: PO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.PO
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pO == null)
            {
                return NotFound();
            }

            return View(pO);
        }

        // GET: PO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PoTime,isDraft")] PO pO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pO);
        }

        // GET: PO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.PO.FindAsync(id);
            if (pO == null)
            {
                return NotFound();
            }
            return View(pO);
        }

        // POST: PO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PoTime,isDraft")] PO pO)
        {
            if (id != pO.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POExists(pO.ID))
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
            return View(pO);
        }

        // GET: PO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.PO
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pO == null)
            {
                return NotFound();
            }

            return View(pO);
        }

        // POST: PO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pO = await _context.PO.FindAsync(id);
            _context.PO.Remove(pO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POExists(int id)
        {
            return _context.PO.Any(e => e.ID == id);
        }
    }
}
