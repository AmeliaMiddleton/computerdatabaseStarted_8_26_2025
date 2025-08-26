using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice8_26_2025_Copy.Data;
using Practice8_26_2025_Copy.Models;

namespace Practice8_26_2025_Copy.Controllers
{
    public class ComputersController : Controller
    {
        private readonly ComputerDbContext _context;

        public ComputersController(ComputerDbContext context)
        {
            _context = context;
        }

        // GET: Computers
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewData["ModelSortParm"] = sortOrder == "Model" ? "model_desc" : "Model";
            ViewData["CurrentFilter"] = searchString;

            var computers = from c in _context.Computers
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                computers = computers.Where(s => s.Brand.Contains(searchString)
                                       || s.Model.Contains(searchString)
                                       || s.Processor.Contains(searchString));
            }

            computers = sortOrder switch
            {
                "brand_desc" => computers.OrderByDescending(s => s.Brand),
                "Model" => computers.OrderBy(s => s.Model),
                "model_desc" => computers.OrderByDescending(s => s.Model),
                _ => computers.OrderBy(s => s.Brand),
            };

            return View(await computers.AsNoTracking().ToListAsync());
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Processor,RamGB,StorageGB,StorageType,OperatingSystem,YearManufactured,PurchasePrice,Notes")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                computer.DateAdded = DateTime.Now;
                computer.IsActive = true;
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Processor,RamGB,StorageGB,StorageType,OperatingSystem,YearManufactured,PurchasePrice,Notes,DateAdded,IsActive")] Computer computer)
        {
            if (id != computer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.Id))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer != null)
            {
                computer.IsActive = false;
                _context.Update(computer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.Id == id);
        }
    }
} 