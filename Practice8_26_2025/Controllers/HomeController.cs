using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice8_26_2025_Copy.Data;

namespace Practice8_26_2025_Copy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ComputerDbContext _context;

        public HomeController(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var computerCount = await _context.Computers.CountAsync();
            var recentComputers = await _context.Computers
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.DateAdded)
                .Take(5)
                .ToListAsync();

            ViewBag.ComputerCount = computerCount;
            ViewBag.RecentComputers = recentComputers;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
} 