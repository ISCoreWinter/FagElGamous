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
    public class MainEntriesController : Controller
    {
        private readonly fagelgamousContext _context;

        public MainEntriesController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: MainEntries1
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.MainEntries.Include(m => m.Burial);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: MainEntries1/Details/5
        public async Task<IActionResult> Details(int? burialId)
        {
            if (burialId == null)
            {
                return NotFound();
            }

            var mainEntries = await _context.MainEntries
                .Include(m => m.Burial)
                .FirstOrDefaultAsync(m => m.EntryId == burialId);
            if (mainEntries == null)
            {
                return NotFound();
            }

            return View(mainEntries);
        }

        // GET: MainEntries1/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            return View();
        }

        // POST: MainEntries1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryId,BurialId,BodyAnalysisYear,YearExcavated,MonthExcavated,DayExcavated,ArtifactsDescription,DescriptionOfTaken,OsteologyNotes,BurialSituation,GamousId,FieldBook,FieldBookPgnumber,DataEntryExpertInitials,DataEntryCheckerInitials,ByuSample,RackNumber,ShelfNumber,Tomb,Cluster,BodySex,GeSex,SexMethod,GeFunctionTotal,AgeRangeAtDeath,AgeEstimateAtDeath,AgeMethod,AgeCode,AgeCodeSingle,BurialPreservation,BurialWrapping,FaceBundle,HairColorCode,HairColor,LengthM,LengthCm,SkullAtMagazine,PostcraniaAtMagazine,ToBeConfirmed,OsteologyUnknownComment,Goods,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,ArtifactFound,BurialSampleTaken,BurialWestToHead,BurialWestToFeet,BurialSouthToHead,BurialSouthToFeet,EastToHead,EastToFeet,BurialDepth,HeadDirection,BurialDirection,Notes1,Notes2,Notes3,Notes4,Notes5,Notes6,Notes7,Notes8,Notes9,TimeEntered,InCluster,ClusterNumber,ShaftNumber,SharedShaft,ExcavationRecorderFirstName,ExcavationRecorderMiddleName,ExcavationRecorderLastName")] MainEntries mainEntries)
        {
            if (ModelState.IsValid)
            {
                mainEntries.BurialId = (_context.BurialRecords.Max(p => p.BurialId));
                mainEntries.EntryId = (_context.MainEntries.Max(p => p.EntryId) + 1);
                _context.Add(mainEntries);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/Confirmation.cshtml");
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", mainEntries.BurialId);
            return View(mainEntries);
        }

        // GET: MainEntries1/Edit/5

        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }


            var mainEntries = await _context.MainEntries.FindAsync(BurialId);
            if (mainEntries == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", mainEntries.BurialId);
            return View(mainEntries);
        }

        // POST: MainEntries1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int BurialId, [Bind("EntryId,BurialId,BodyAnalysisYear,YearExcavated,MonthExcavated,DayExcavated,ArtifactsDescription,DescriptionOfTaken,OsteologyNotes,BurialSituation,GamousId,FieldBook,FieldBookPgnumber,DataEntryExpertInitials,DataEntryCheckerInitials,ByuSample,RackNumber,ShelfNumber,Tomb,Cluster,BodySex,GeSex,SexMethod,GeFunctionTotal,AgeRangeAtDeath,AgeEstimateAtDeath,AgeMethod,AgeCode,AgeCodeSingle,BurialPreservation,BurialWrapping,FaceBundle,HairColorCode,HairColor,LengthM,LengthCm,SkullAtMagazine,PostcraniaAtMagazine,ToBeConfirmed,OsteologyUnknownComment,Goods,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,ArtifactFound,BurialSampleTaken,BurialWestToHead,BurialWestToFeet,BurialSouthToHead,BurialSouthToFeet,EastToHead,EastToFeet,BurialDepth,HeadDirection,BurialDirection,Notes1,Notes2,Notes3,Notes4,Notes5,Notes6,Notes7,Notes8,Notes9,TimeEntered,InCluster,ClusterNumber,ShaftNumber,SharedShaft,ExcavationRecorderFirstName,ExcavationRecorderMiddleName,ExcavationRecorderLastName")] MainEntries mainEntries)
        {
            if (BurialId != mainEntries.EntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainEntries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEntriesExists(mainEntries.EntryId))
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
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", mainEntries.BurialId);
            return View(mainEntries);
        }

        // GET: MainEntries1/Delete/5
        public async Task<IActionResult> Delete(int? burialId)
        {
            if (burialId == null)
            {
                return NotFound();
            }

            var mainEntries = await _context.MainEntries
                .Include(m => m.Burial)
                .FirstOrDefaultAsync(m => m.EntryId == burialId);
            if (mainEntries == null)
            {
                return NotFound();
            }

            return View(mainEntries);
        }

        // POST: MainEntries1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int burialId)
        {
            var mainEntries = await _context.MainEntries.FindAsync(burialId);
            _context.MainEntries.Remove(mainEntries);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/Confirmation.cshtml");
        }

        private bool MainEntriesExists(int burialId)
        {
            return _context.MainEntries.Any(e => e.EntryId == burialId);
        }
    }
}
