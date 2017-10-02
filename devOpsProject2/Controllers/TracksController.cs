using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using devOpsProject2.Context;
using devOpsProject2.Models;

namespace devOpsProject2.Controllers
{
    public class TracksController : Controller
    {
        private readonly MySqlContext _context;

        public TracksController(MySqlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? cdId)
        {
            if (cdId == null) return NotFound();
            var track = await _context.Track.Where(t => t.CDId == cdId).ToListAsync();
            return View(track);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .SingleOrDefaultAsync(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        public IActionResult Create(int cdId)
        {
            ViewBag.CDId = cdId;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDId,Title,Authors,Duration")] Track track)
        {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track.SingleOrDefaultAsync(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CDId,Title,Authors,Duration")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
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
            return View(track);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .SingleOrDefaultAsync(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Track.SingleOrDefaultAsync(m => m.Id == id);
            _context.Track.Remove(track);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.Id == id);
        }
    }
}
