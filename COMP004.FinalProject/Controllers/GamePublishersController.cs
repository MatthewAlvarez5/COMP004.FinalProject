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
    public class GamePublishersController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public GamePublishersController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: GamePublishers
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.GamePublishers.Include(g => g.Developer).Include(g => g.Game).Include(g => g.Publisher);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: GamePublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GamePublishers == null)
            {
                return NotFound();
            }

            var gamePublisher = await _context.GamePublishers
                .Include(g => g.Developer)
                .Include(g => g.Game)
                .Include(g => g.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamePublisher == null)
            {
                return NotFound();
            }

            return View(gamePublisher);
        }

        // GET: GamePublishers/Create
        public IActionResult Create()
        {
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId");
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId");
            return View();
        }

        // POST: GamePublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,DeveloperId,PublisherId")] GamePublisher gamePublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gamePublisher.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePublisher.GameId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", gamePublisher.PublisherId);
            return View(gamePublisher);
        }

        // GET: GamePublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GamePublishers == null)
            {
                return NotFound();
            }

            var gamePublisher = await _context.GamePublishers.FindAsync(id);
            if (gamePublisher == null)
            {
                return NotFound();
            }
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gamePublisher.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePublisher.GameId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", gamePublisher.PublisherId);
            return View(gamePublisher);
        }

        // POST: GamePublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,DeveloperId,PublisherId")] GamePublisher gamePublisher)
        {
            if (id != gamePublisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePublisherExists(gamePublisher.Id))
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
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gamePublisher.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePublisher.GameId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", gamePublisher.PublisherId);
            return View(gamePublisher);
        }

        // GET: GamePublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GamePublishers == null)
            {
                return NotFound();
            }

            var gamePublisher = await _context.GamePublishers
                .Include(g => g.Developer)
                .Include(g => g.Game)
                .Include(g => g.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamePublisher == null)
            {
                return NotFound();
            }

            return View(gamePublisher);
        }

        // POST: GamePublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GamePublishers == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.GamePublishers'  is null.");
            }
            var gamePublisher = await _context.GamePublishers.FindAsync(id);
            if (gamePublisher != null)
            {
                _context.GamePublishers.Remove(gamePublisher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamePublisherExists(int id)
        {
          return (_context.GamePublishers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
