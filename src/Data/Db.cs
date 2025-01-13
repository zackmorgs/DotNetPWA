using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;

namespace Data
{
    public class Db : IdentityDbContext<ApplicationUser>
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
            // WeatherForecasts will be initialized by Entity Framework
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}