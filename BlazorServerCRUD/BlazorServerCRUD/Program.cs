using BlazorServerCRUD.Data;
using BlazorServerCRUD.Interfaces;
using BlazorServerCRUD.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor(); // Blazor
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<IGameService, GameService>();

            // local runs
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
            });

            var app = builder.Build();

            // seeding database if it is empty
            Seed.SeedData(app);

            // Configuthe HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub(); // allows you to establish a connection with the browser via SignalR
            app.MapFallbackToPage("/_Host"); // default page - Pages/_Host.cshtml

            app.Run();
        }
    }
}