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
    public class RaceTableController : Controller
    {
        private readonly AppDbContext _context;

        public RaceTableController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RaceTable
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceTables.ToListAsync());
        }

        // GET: RaceTable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTable = await _context.RaceTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceTable == null)
            {
                return NotFound();
            }

            return View(raceTable);
        }

        // GET: RaceTable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size,SubType,Traits")] RaceTable raceTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceTable);
        }

        // GET: RaceTable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTable = await _context.RaceTables.FindAsync(id);
            if (raceTable == null)
            {
                return NotFound();
            }
            return View(raceTable);
        }

        // POST: RaceTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,SubType,Traits")] RaceTable raceTable)
        {
            if (id != raceTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceTableExists(raceTable.Id))
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
            return View(raceTable);
        }

        // GET: RaceTable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTable = await _context.RaceTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceTable == null)
            {
                return NotFound();
            }

            return View(raceTable);
        }

        // POST: RaceTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceTable = await _context.RaceTables.FindAsync(id);
            if (raceTable != null)
            {
                _context.RaceTables.Remove(raceTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceTableExists(int id)
        {
            return _context.RaceTables.Any(e => e.Id == id);
        }
    }
}
