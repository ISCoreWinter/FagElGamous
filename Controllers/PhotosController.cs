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
    public class PhotosController : Controller
    {
        private readonly fagelgamousContext _context;

        public PhotosController(fagelgamousContext context)
        {
            _context = context;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            var fagelgamousContext = _context.Photos.Include(p => p.Burial);
            return View(await fagelgamousContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .Include(p => p.Burial)
                .FirstOrDefaultAsync(m => m.PhotoId == BurialId);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoId,Description,Filestring,BurialId")] Photos photos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", photos.BurialId);
            return View(photos);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos.FindAsync(BurialId);
            if (photos == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", photos.BurialId);
            return View(photos);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BurialId, [Bind("PhotoId,Description,Filestring,BurialId")] Photos photos)
        {
            if (BurialId != photos.PhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotosExists(photos.PhotoId))
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
            ViewData["BurialId"] = new SelectList(_context.BurialRecords, "BurialId", "BurialId", photos.BurialId);
            return View(photos);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? BurialId)
        {
            if (BurialId == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .Include(p => p.Burial)
                .FirstOrDefaultAsync(m => m.PhotoId == BurialId);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BurialId)
        {
            var photos = await _context.Photos.FindAsync(BurialId);
            _context.Photos.Remove(photos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotosExists(int BurialId)
        {
            return _context.Photos.Any(e => e.PhotoId == BurialId);
        }
    }
}
