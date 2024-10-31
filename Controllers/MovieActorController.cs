using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fall2024_Assignment3_erweber3.Data;
using Fall2024_Assignment3_erweber3.Models;

namespace Fall2024_Assignment3_erweber3.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieActorController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: MovieActor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieActor
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieActor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // GET: MovieActor/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name");
            return View();
        }

        // POST: MovieActor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,ActorId")] MovieActor movieActor)
        {
            bool alreadyExists = await _context.MovieActor
                .AnyAsync(ma => ma.MovieId == movieActor.MovieId && ma.ActorId == movieActor.ActorId);

            if (ModelState.IsValid && !alreadyExists)
            {
                _context.Add(movieActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Cannot add the same actor to the same movie multiple times.");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // GET: MovieActor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // POST: MovieActor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,ActorId")] MovieActor movieActor)
        {
            if (id != movieActor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieActorExists(movieActor.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // GET: MovieActor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // POST: MovieActor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieActor = await _context.MovieActor.FindAsync(id);
            if (movieActor != null)
            {
                _context.MovieActor.Remove(movieActor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieActorExists(int id)
        {
            return _context.MovieActor.Any(e => e.Id == id);
        }
    }
}
