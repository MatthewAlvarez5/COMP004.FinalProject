using COMP004.FinalProject.Models;
using Microsoft.EntityFrameworkCore;


namespace COMP004.FinalProject.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GamePublisher> GamePublishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}