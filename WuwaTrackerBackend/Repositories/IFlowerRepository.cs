using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public interface IFlowerRepository
    {
        IEnumerable<Flower> GetAll();
        void CreateFlower(Flower flower);
        void UpdateFlower(Flower flower);
        void DeleteFlower(Guid id);
        IEnumerable<Flower> GetFlower(Guid id);
        
    }
}
