using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlazorServerCRUD.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
    }
}
