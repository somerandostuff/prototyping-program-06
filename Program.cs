using Assignment_2_NEW.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2_NEW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Builder.Services.AddControllersWithViews();

#pragma warning disable ASP0000

            var Provider = Builder.Services.BuildServiceProvider();
            var Configuration = Provider.GetRequiredService<IConfiguration>();
            Builder.Services.AddDbContext<AssignmentDatabaseContext>(Item => Item.UseSqlServer(Configuration.GetConnectionString("Assignment_Database")));
            Builder.Services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

#pragma warning restore ASP0000

            var App = Builder.Build();

            // Configure the HTTP request pipeline.
            if (!App.Environment.IsDevelopment())
            {
                App.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                App.UseHsts();
            }

            App.UseHttpsRedirection();
            App.UseStaticFiles();
            App.UseSession();

            App.UseRouting();

            App.UseAuthorization();

            App.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Customer}");

            App.Run();
        }
    }
}