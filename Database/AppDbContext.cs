using bookShare.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace bookShare.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Books> books { get; set; }
    }
}
