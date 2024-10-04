using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Containers
{
    public interface IFlowerContainer
    {
        IEnumerable<FlowerDTO> GetAll();
        void CreateFlower(FlowerDTO dto);
        void UpdateFlower(FlowerDTO dto);
        void DeleteFlower(Guid id);
        IEnumerable<FlowerDTO> GetFlower(Guid id);
    }
}
