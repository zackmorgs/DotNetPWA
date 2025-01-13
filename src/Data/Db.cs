using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;

namespace Data
{
    public class Db(DbContextOptions<Db> options) : IdentityDbContext<ApplicationUser>(options)
    {
    }
}