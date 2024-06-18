using Microsoft.EntityFrameworkCore;

namespace WuwaTrackerBackend.Models
{
    public class WuwaContext : DbContext
    {
        public WuwaContext(DbContextOptions<WuwaContext> options) : base(options)
        {

        }
    }
}
