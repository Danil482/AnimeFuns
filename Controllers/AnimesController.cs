using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeFuns.Models;
using Microsoft.AspNetCore.Authorization;

namespace AnimeFuns.Controllers
{
    public class AnimesController : Controller
    {
        private readonly AnimeDBContext _context;

        public AnimesController(AnimeDBContext context)
        {
            _context = context;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
              return _context.Animes != null ? 
                          View(await _context.Animes.ToListAsync()) :
                          Problem("Entity set 'AnimeDBContext.Animes'  is null.");
        }

        // GET: Animes/Details/5
        [Route("BorutoDetails/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,JapanTitle,Description,Type,Genre,Date,CommentCount,ViewsCount,Studio,Status,Diration,ImagePath")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }
        [Authorize(Roles = "Admin")]
        [Route("ViewAll")]
        public IActionResult Categories()
        {
            return View();
        }
        [Route("BorutoWatching")]
        public IActionResult AnimeWatching()
        {
            return View();
        }
        [Route("BlogDetails")]
        public IActionResult BlogDetails()
        {
            return View();
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,JapanTitle,Description,Type,Genre,Date,CommentCount,ViewsCount,Studio,Status,Diration,ImagePath")] Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.Id))
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
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animes == null)
            {
                return Problem("Entity set 'AnimeDBContext.Animes'  is null.");
            }
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
          return (_context.Animes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
