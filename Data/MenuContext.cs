using Microsoft.EntityFrameworkCore;

namespace FoodMenuApp.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> contextOptions) 
        {
            
        }
    }
}
