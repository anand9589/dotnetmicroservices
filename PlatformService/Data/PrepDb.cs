using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if (dbContext.Platforms.Any())
            {
                Console.WriteLine("--> We already have data!");
            }
            else
            {
                Console.WriteLine("--> Seeding Data...");

                dbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });

                dbContext.SaveChanges();
            }
        }
    }
}