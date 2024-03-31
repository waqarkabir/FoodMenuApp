using FoodMenuApp.Data;
using FoodMenuApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FoodMenuApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly MenuContext context;

        public MenuController(ILogger<MenuController> logger, MenuContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
           var model = await context.Dishes.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        { 
            var detail = await context.Dishes
                .Include(x => x.DishIngredients)
                .ThenInclude(y => y.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (detail is null)
            {
                return NotFound();
            }
            
            return View(detail);
        }
    }
}
