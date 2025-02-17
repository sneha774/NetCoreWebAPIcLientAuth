using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreWebAPIcLientAuth.Models;

namespace NetCoreWebAPIcLientAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; } // DbSet corresponds to a table in the database
        public DbSet<Comment> Comments { get; set; }
    }
}
