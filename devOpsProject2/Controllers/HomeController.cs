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
    public class HomeController : Controller
    {
        private readonly MySqlContext _context;

        public HomeController(MySqlContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.CD.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Artists,ReleaseYear,TotalTracks,TotalDuration")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cD);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD.SingleOrDefaultAsync(m => m.Id == id);
            if (cD == null)
            {
                return NotFound();
            }
            return View(cD);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Artists,ReleaseYear,TotalTracks,TotalDuration")] CD cD)
        {
            if (id != cD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.Id))
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
            return View(cD);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cD = await _context.CD.SingleOrDefaultAsync(m => m.Id == id);
            _context.CD.Remove(cD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
            return _context.CD.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
