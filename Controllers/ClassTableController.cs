using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DndCharacterCreator.Data;
using DndCharacterCreator.Models;

namespace DndCharacterCreator.Controllers
{
    public class ClassTableController : Controller
    {
        private readonly AppDbContext _context;

        public ClassTableController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClassTable
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassTables.ToListAsync());
        }

        // GET: ClassTable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTable = await _context.ClassTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classTable == null)
            {
                return NotFound();
            }

            return View(classTable);
        }

        // GET: ClassTable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ClassTable classTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classTable);
        }

        // GET: ClassTable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTable = await _context.ClassTables.FindAsync(id);
            if (classTable == null)
            {
                return NotFound();
            }
            return View(classTable);
        }

        // POST: ClassTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ClassTable classTable)
        {
            if (id != classTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTableExists(classTable.Id))
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
            return View(classTable);
        }

        // GET: ClassTable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTable = await _context.ClassTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classTable == null)
            {
                return NotFound();
            }

            return View(classTable);
        }

        // POST: ClassTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classTable = await _context.ClassTables.FindAsync(id);
            if (classTable != null)
            {
                _context.ClassTables.Remove(classTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTableExists(int id)
        {
            return _context.ClassTables.Any(e => e.Id == id);
        }
    }
}
