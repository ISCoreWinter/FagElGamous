using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamous.Models;

namespace FagElGamous.Controllers
{
    public class CarbonDatingsController : Controller
    {
        private readonly fagelgamousContext _context;

        public CarbonDatingsController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: CarbonDatings
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.CarbonDating.Include(c => c.BioSample).Include(c => c.Burial);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: CarbonDatings/Details/5
        public async Task<IActionResult> Details(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var carbonDating = await _context.CarbonDating
                .Include(c => c.BioSample)
                .Include(c => c.Burial)
                .FirstOrDefaultAsync(m => m.CarbonDatingId ==BurialId);
            if (carbonDating == null)
            {
                return NotFound();
            }

            return View(carbonDating);
        }

        // GET: CarbonDatings/Create
        public IActionResult Create()
        {
            ViewData["BioSampleId"] = new SelectList(_context.BiologicalSamples, "BioSampleId", "BioSampleId");
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            return View();
        }

        // POST: CarbonDatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarbonDatingId,BurialId,BioSampleId,RackNumber,TubeNumber,Description,SizeMl,Foci,C14Sample2017,LocationDescription,ResearchQuestions,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] CarbonDating carbonDating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carbonDating);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/Confirmation.cshtml");
            }
            ViewData["BioSampleId"] = new SelectList(_context.BiologicalSamples, "BioSampleId", "BioSampleId", carbonDating.BioSampleId);
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", carbonDating.BurialId);
            return View(carbonDating);
        }

        // GET: CarbonDatings/Edit/5
        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var carbonDating = await _context.CarbonDating.FindAsync(BurialId);
            if (carbonDating == null)
            {
                return NotFound();
            }
            ViewData["BioSampleId"] = new SelectList(_context.BiologicalSamples, "BioSampleId", "BioSampleId", carbonDating.BioSampleId);
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", carbonDating.BurialId);
            return View(carbonDating);
        }

        // POST: CarbonDatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BurialId, [Bind("CarbonDatingId,BurialId,BioSampleId,RackNumber,TubeNumber,Description,SizeMl,Foci,C14Sample2017,LocationDescription,ResearchQuestions,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] CarbonDating carbonDating)
        {
            if (BurialId != carbonDating.CarbonDatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carbonDating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarbonDatingExists(carbonDating.CarbonDatingId))
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
            ViewData["BioSampleId"] = new SelectList(_context.BiologicalSamples, "BioSampleId", "BioSampleId", carbonDating.BioSampleId);
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", carbonDating.BurialId);
            return View("Confirmation");
        }

        // GET: CarbonDatings/Delete/5
        public async Task<IActionResult> Delete(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var carbonDating = await _context.CarbonDating
                .Include(c => c.BioSample)
                .Include(c => c.Burial)
                .FirstOrDefaultAsync(m => m.CarbonDatingId ==BurialId);
            if (carbonDating == null)
            {
                return NotFound();
            }

            return View(carbonDating);
        }

        // POST: CarbonDatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BurialId)
        {
            var carbonDating = await _context.CarbonDating.FindAsync(BurialId);
            _context.CarbonDating.Remove(carbonDating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarbonDatingExists(int BurialId)
        {
            return _context.CarbonDating.Any(e => e.CarbonDatingId == BurialId);
        }
    }
}
