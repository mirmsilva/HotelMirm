using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelInventory.Data;
using HotelInventory.Models;

namespace HotelInventory.Controllers
{
    public class HotelsController : Controller
    {
        private readonly InventoryContext _context;

        public HotelsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var hotels = from h in _context.Hotels
                         select h;
            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString) || h.City.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    hotels = hotels.OrderByDescending(h => h.Name);
                    break;
                case "city_desc":
                    hotels = hotels.OrderByDescending(h => h.City);
                    break;
                default:
                    hotels = hotels.OrderBy(h => h.Name);
                    break;
            }
            return View(await hotels.AsNoTracking().ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(hr => hr.HotelRooms)
                .ThenInclude(r => r.Room)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,City,State")] Hotel hotel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(hotel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,City,State")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete Failed, Try Again";
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if(hotel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment the ex variable and write a log
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.ID == id);
        }
    }
}
