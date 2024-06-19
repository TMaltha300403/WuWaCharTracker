using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Containers
{
    public interface ITacetCoreContainer
    {
        IEnumerable<TacetCoreDTO> GetAll();
        void CreateTacetCore(TacetCoreDTO dto);
        void UpdateTacetCore(TacetCoreDTO dto);
        void DeleteTacetCore(Guid id);
    }
}
