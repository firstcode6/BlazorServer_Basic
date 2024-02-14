using BlazorServerCRUD.Models;
using System.Diagnostics;
using System.Net;

namespace BlazorServerCRUD.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Games.Any())
                {
                    context.Games.AddRange(new List<Game>()
                    {
                        new Game
                        {
                           // Id = 1,
                            Name = "Half Life 2",
                            Developer = "Valve",
                            Release = new DateTime(2004, 11, 16)
                        },
                        new Game
                        {
                           // Id = 2,
                            Name = "Day of the Tentacle",
                            Developer = "Lucas Arts",
                            Release = new DateTime(1993, 5, 25)
                        }
                    });
                    context.SaveChanges();
                }
               
                
            }
        }
    }
}
