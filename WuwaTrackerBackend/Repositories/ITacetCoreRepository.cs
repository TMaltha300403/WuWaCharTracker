using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public interface ITacetCoreRepository
    {
        IEnumerable<TacetCore> GetAll();
        void CreateTacetCore(TacetCore tacetCore);
        void UpdateTacetCore(TacetCore tacetCore);
        void DeleteTacetCore(Guid id);
    }
}
