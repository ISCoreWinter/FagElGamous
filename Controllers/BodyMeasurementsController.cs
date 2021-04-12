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
    public class BodyMeasurementsController : Controller
    {
        private readonly fagelgamousContext _context;

        public BodyMeasurementsController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: BodyMeasurements
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.BodyMeasurements.Include(b => b.Burial).Include(b => b.Entry);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: BodyMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements
                .Include(b => b.Burial)
                .Include(b => b.Entry)
                .FirstOrDefaultAsync(m => m.EntryId == id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId");
            return View();
        }

        // POST: BodyMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryId,BurialId,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedicalIpRamus,DorsalPitting,FemurHead,HumerusHead,PubicSymphysis,BoneLength,MedicalClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,PreservationIndex,EstimateLivingStature,PathologyAnomalies,EpiphysealUnion,Osteophytosis")] BodyMeasurements bodyMeasurements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyMeasurements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", bodyMeasurements.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", bodyMeasurements.EntryId);
            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements.FindAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", bodyMeasurements.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", bodyMeasurements.EntryId);
            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntryId,BurialId,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedicalIpRamus,DorsalPitting,FemurHead,HumerusHead,PubicSymphysis,BoneLength,MedicalClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,PreservationIndex,EstimateLivingStature,PathologyAnomalies,EpiphysealUnion,Osteophytosis")] BodyMeasurements bodyMeasurements)
        {
            if (id != bodyMeasurements.EntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyMeasurements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyMeasurementsExists(bodyMeasurements.EntryId))
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
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", bodyMeasurements.BurialId);
            ViewData["EntryId"] = new SelectList(_context.MainEntries, "EntryId", "EntryId", bodyMeasurements.EntryId);
            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements
                .Include(b => b.Burial)
                .Include(b => b.Entry)
                .FirstOrDefaultAsync(m => m.EntryId == id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyMeasurements = await _context.BodyMeasurements.FindAsync(id);
            _context.BodyMeasurements.Remove(bodyMeasurements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyMeasurementsExists(int id)
        {
            return _context.BodyMeasurements.Any(e => e.EntryId == id);
        }
    }
}
