using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Entites;
using WS.Infrastruture.Sql;

namespace PresentataionHost.Controllers
{
    public class MediaController : Controller
    {
        private readonly DemoContext _context;

        public MediaController(DemoContext context)
        {
            _context = context;
        }

        // GET: Media
        public async Task<IActionResult> Index()
        {
            var demoContext = _context.Products.Include(m => m.Medias);
            return View(await demoContext.ToListAsync());
        }

        // GET: Media/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var Product = _context.Medias.Single(b => b.MediaId == 1);

        //    _context.Entry(Product).Collection(b => b.Posts)
        //       .Query().ToList();

        //    var media = await _context.Medias
        //        .FirstOrDefaultAsync(m => m.MediaId == id);

        //    var Products = _context.Products.Include(a => a.Medias).ToList();
        //    var t = _context.Entry(Products)
        //     .Collection(media)
        //    .Query()
        //    .Where(sc => sc.CourseName == "Maths")
        //    .FirstOrDefault();

        //    if (media == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(media);
        //}

        // GET: Media/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name");
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaId,Path,ProductId")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
      
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name");
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name", media.ProductId);
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediaId,Path,ProductId")] Media media)
        {
            if (id != media.MediaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.MediaId))
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
            //ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Name", media.ProductId);
            return View(media);
        }

        // GET: Media/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var media = await _context.Medias
        //        .Include(m => m.Product)
        //        .FirstOrDefaultAsync(m => m.MediaId == id);
        //    if (media == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(media);
        //}

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Medias.FindAsync(id);
            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Medias.Any(e => e.MediaId == id);
        }
    }
}
