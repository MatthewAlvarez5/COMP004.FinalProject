using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP004.FinalProject.Data;
using COMP004.FinalProject.Models;

namespace COMP004.FinalProject.Controllers
{
    public class GamePlatformsController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public GamePlatformsController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: GamePlatforms
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.GamePlatforms.Include(g => g.Game).Include(g => g.Platform);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: GamePlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GamePlatforms == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // GET: GamePlatforms/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId");
            return View();
        }

        // POST: GamePlatforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,PlatformId")] GamePlatform gamePlatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GamePlatforms == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms.FindAsync(id);
            if (gamePlatform == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // POST: GamePlatforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,PlatformId")] GamePlatform gamePlatform)
        {
            if (id != gamePlatform.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlatformExists(gamePlatform.Id))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GamePlatforms == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // POST: GamePlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GamePlatforms == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.GamePlatforms'  is null.");
            }
            var gamePlatform = await _context.GamePlatforms.FindAsync(id);
            if (gamePlatform != null)
            {
                _context.GamePlatforms.Remove(gamePlatform);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamePlatformExists(int id)
        {
          return (_context.GamePlatforms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
