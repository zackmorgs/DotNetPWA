using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;

using Duende.IdentityServer.EntityFramework.Options;

using Models;

namespace Data
{
    public class Db : ApiAuthorizationDbContext<ApplicationUser>
    {
        public Db(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
    }
}