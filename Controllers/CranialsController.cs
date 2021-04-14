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
    public class CranialsController : Controller
    {
        private readonly fagelgamousContext _context;

        public CranialsController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: Cranials1
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.Cranial.Include(c => c.Burial).Include(c => c.Entry);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: Cranials1/Details/5
        public async Task<IActionResult> Details(int? EntryId)
        {
            if (EntryId == null)
            {
                return NotFound();
            }

            var cranial = await _context.Cranial
                .Include(c => c.Burial)
                .Include(c => c.Entry)
                .FirstOrDefaultAsync(m => m.EntryId == EntryId);
            if (cranial == null)
            {
                return NotFound();
            }

            return View(cranial);
        }

        // GET: Cranials1/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId");
            return View();
        }

        // POST: Cranials1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryId,BurialId,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,BasilarSuture,ForemanMagnum,ToothAttrition,ToothEruption,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,TemporalMandibularJointOsteoarthritisTmjoa,LinearHypoplasiaEnamel,SkullYear,SkullMonth,SkullDate,Robust")] Cranial cranial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cranial);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/Confirmation.cshtml");
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", cranial.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", cranial.EntryId);
            return View(cranial);
        }

        // GET: Cranials1/Edit/5
        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var cranial = await _context.Cranial.FindAsync(BurialId);
            if (cranial == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", cranial.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", cranial.EntryId);
            return View(cranial);
        }

        // POST: Cranials1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EntryId, [Bind("EntryId,BurialId,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,BasilarSuture,ForemanMagnum,ToothAttrition,ToothEruption,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,TemporalMandibularJointOsteoarthritisTmjoa,LinearHypoplasiaEnamel,SkullYear,SkullMonth,SkullDate,Robust")] Cranial cranial)
        {
            if (EntryId != cranial.EntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cranial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CranialExists(cranial.EntryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("~/Views/Home/Confirmation.cshtml");
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", cranial.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", cranial.EntryId);
            return View(cranial);
        }

        // GET: Cranials1/Delete/5
        public async Task<IActionResult> Delete(int? EntryId)
        {
            if (EntryId == null)
            {
                return NotFound();
            }

            var cranial = await _context.Cranial
                .Include(c => c.Burial)
                .Include(c => c.Entry)
                .FirstOrDefaultAsync(m => m.EntryId == EntryId);
            if (cranial == null)
            {
                return NotFound();
            }

            return View(cranial);
        }

        // POST: Cranials1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EntryId)
        {
            var cranial = await _context.Cranial.FindAsync(EntryId);
            _context.Cranial.Remove(cranial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CranialExists(int EntryId)
        {
            return _context.Cranial.Any(e => e.EntryId == EntryId);
        }
    }
}
