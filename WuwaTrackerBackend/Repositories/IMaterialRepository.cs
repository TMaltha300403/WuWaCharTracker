using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAll();
        void CreateMaterial(Material material);
        void UpdateMaterial(Material material);
        void DeleteMaterial(Guid id);
    }
}
