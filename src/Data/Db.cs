using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class Db : IdentityDbContext<ApplicationUser>
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Add any custom model configurations here
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
