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
    public class BurialRecordsController : Controller
    {
        private readonly fagelgamousContext _context;

        public BurialRecordsController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: BurialRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.BurialRecords.ToListAsync());
        }

        // GET: BurialRecords/Details/5
        public async Task<IActionResult> Details(int? burialId)
        {
            if (burialId == null)
            {
                return NotFound();
            }

            var burialRecords = await _context.BurialRecords
                .FirstOrDefaultAsync(m => m.BurialId == burialId);
            if (burialRecords == null)
            {
                return NotFound();
            }

            return View(burialRecords);
        }

        // GET: BurialRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BurialRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,Photo,BuriedGoods,BurialNumber")] BurialRecords burialRecords)
        {
            if (ModelState.IsValid)
            {
                burialRecords.BurialId = (_context.BurialRecords.Max(p => p.BurialId) + 1);
                _context.Add(burialRecords);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/Confirmation.cshtml");
            }
            return View(burialRecords);
        }

        // GET: BurialRecords/Edit/5
        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var burialRecords = await _context.BurialRecords.FindAsync(BurialId);
            if (burialRecords == null)
            {
                return NotFound();
            }
            return View(burialRecords);
        }

        // POST: BurialRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BurialId, [Bind("BurialId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,Photo,BuriedGoods,BurialNumber")] BurialRecords burialRecords)
        {
            if (BurialId != burialRecords.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burialRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialRecordsExists(burialRecords.BurialId))
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
            return View(burialRecords);
        }

        // GET: BurialRecords/Delete/5
        public async Task<IActionResult> Delete(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var burialRecords = await _context.BurialRecords
                .FirstOrDefaultAsync(m => m.BurialId == BurialId);
            if (burialRecords == null)
            {
                return NotFound();
            }

            return View(burialRecords);
        }

        // POST: BurialRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BurialId)
        {
            var burialRecords = await _context.BurialRecords.FindAsync(BurialId);
            _context.BurialRecords.Remove(burialRecords);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/Confirmation.cshtml");
        }

        private bool BurialRecordsExists(int BurialId)
        {
            return _context.BurialRecords.Any(e => e.BurialId == BurialId);
        }
    }
}
