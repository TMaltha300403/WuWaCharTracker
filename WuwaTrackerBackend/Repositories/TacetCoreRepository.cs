using Microsoft.EntityFrameworkCore;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public class TacetCoreRepository : ITacetCoreRepository
    {
        private readonly WuwaContext _context;

        public TacetCoreRepository(WuwaContext context)
        {
            _context = context;
        }
        public IEnumerable<TacetCore> GetAll()
        {
            return _context.TacetCores
                .ToArray();
        }

        public void CreateTacetCore(TacetCore tacetCore)
        {
            _context.TacetCores.Add(tacetCore);
            _context.SaveChanges();
        }

        public void DeleteTacetCore(Guid id)
        {
            _context.TacetCores.Remove(_context.TacetCores.SingleOrDefault(a => a.ID == id));
            _context.SaveChanges();
        }

        public void UpdateTacetCore(TacetCore tacetCore)
        {
            _context.TacetCores.Update(tacetCore);
            _context.SaveChanges();
        }
    }
}
