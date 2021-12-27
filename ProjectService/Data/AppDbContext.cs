using Microsoft.EntityFrameworkCore;
using ProjectService.Models;

namespace ProjectService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
    }
}