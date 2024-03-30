using FoodMenuApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MenuContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MenuDb")));
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            if (app.Environment.IsDevelopment())
            {
                //For Auto updating migration to db

                //using (var scope = app.Services.CreateScope())
                //{
                //    var context = scope.ServiceProvider.GetRequiredService<MenuContext>();
                //    context.Database.Migrate();
                //}
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
