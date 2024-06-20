using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Containers
{
    public interface IMaterialContainer
    {
        IEnumerable<MaterialDTO> GetAll();
        void createMaterial(MaterialDTO dto);
        void UpdateMaterial(MaterialDTO dto);
        void DeleteMaterial(Guid id);
    }
}
