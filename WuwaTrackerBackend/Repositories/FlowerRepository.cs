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

        public IEnumerable<Flower> GetFlower(Guid id)
        {
            return _context.Flowers.Where(a => a.ID == id);
        }

        public IEnumerable<Location> GetFlowerLocations(Guid id)
        {
            return _context.Flowers
                .Where(f => f.ID == id)
                .SelectMany(f => f.Locations)
                .ToArray();

        }
    }
}

