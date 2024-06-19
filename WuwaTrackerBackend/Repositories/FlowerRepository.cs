using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly WuwaContext _context;

        public FlowerRepository(WuwaContext context)
        {
            _context = context;
        }

        public IEnumerable<Flower> GetAll()
        {
            return _context.Flowers
                .ToArray();
        }

        public void CreateFlower(Flower flower)
        {
            _context.Flowers.Add(flower);
            _context.SaveChanges();
        }

        public void DeleteFlower(Guid Id)
        {
            _context.Flowers.Remove(_context.Flowers.SingleOrDefault(a => a.ID == Id));
            _context.SaveChanges();
        }

        public void UpdateFlower(Flower flower)
        {
            _context.Flowers.Update(flower);
            _context.SaveChanges();
        }
    }
}
