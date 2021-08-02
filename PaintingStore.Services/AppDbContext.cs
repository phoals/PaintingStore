using Microsoft.EntityFrameworkCore;
using PaintingStore.Models;

namespace PaintingStore.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Painting> Paintings { get; set; }
    }
}
