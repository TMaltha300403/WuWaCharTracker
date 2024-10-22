using Microsoft.EntityFrameworkCore;

namespace WuwaTrackerBackend.Models
{
    public class WuwaContext : DbContext
    {
        public WuwaContext(DbContextOptions<WuwaContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<TacetCore> TacetCores { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
