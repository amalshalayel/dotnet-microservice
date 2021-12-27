using Microsoft.EntityFrameworkCore;
using TeamService.Models;

namespace TeamService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Team> Teams { get; set; }
    }
}