using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;
using FagElGamous.Models.ViewModels;

namespace FagElGamous.Controllers
{
    public class BiologicalSamplesController : Controller
    {
        private readonly fagelgamousContext _context;

        public BiologicalSamplesController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: BiologicalSamples
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.BiologicalSamples.Include(b => b.Burial);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: BiologicalSamples/Details/5
        public async Task<IActionResult> Details(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var biologicalSamples = await _context.BiologicalSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == BurialId);
            if (biologicalSamples == null)
            {
                return NotFound();
            }

            return View(biologicalSamples);
        }

        // GET: BiologicalSamples/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            return View();
        }

        // POST: BiologicalSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioSampleId,BurialId,RackNumber,BagNimber,ClusterNumber,Month,Day,Year,PreviouslySampled,Notes,Initials")] BiologicalSamples biologicalSamples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biologicalSamples);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/Confirmation.cshtml");
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", biologicalSamples.BurialId);
            return View(biologicalSamples);
        }

        // GET: BiologicalSamples/Edit/5
        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var biologicalSamples = await _context.BiologicalSamples.FindAsync(BurialId);
            if (biologicalSamples == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", biologicalSamples.BurialId);
            return View(biologicalSamples);
        }

        // POST: BiologicalSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BurialId, [Bind("BioSampleId,BurialId,RackNumber,BagNimber,ClusterNumber,Month,Day,Year,PreviouslySampled,Notes,Initials")] BiologicalSamples biologicalSamples)
        {
            if (BurialId != biologicalSamples.BioSampleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biologicalSamples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologicalSamplesExists(biologicalSamples.BioSampleId))
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
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", biologicalSamples.BurialId);
            return View("Confirmation");
        }

        // GET: BiologicalSamples/Delete/5
        public async Task<IActionResult> Delete(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var biologicalSamples = await _context.BiologicalSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == BurialId);
            if (biologicalSamples == null)
            {
                return NotFound();
            }

            return View(biologicalSamples);
        }

        // POST: BiologicalSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BurialId)
        {
            var biologicalSamples = await _context.BiologicalSamples.FindAsync(BurialId);
            _context.BiologicalSamples.Remove(biologicalSamples);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiologicalSamplesExists(int BurialId)
        {
            return _context.BiologicalSamples.Any(e => e.BioSampleId == BurialId);
        }
    }
}
