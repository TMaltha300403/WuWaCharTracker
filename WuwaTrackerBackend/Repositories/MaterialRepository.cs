using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly WuwaContext _context;

        public MaterialRepository(WuwaContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetAll()
        {
            return _context.Materials
                .ToArray();
        }

        public void CreateMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public void UpdateMaterial(Material material)
        {
            _context.Materials.Update(material);
            _context.SaveChanges();
        }

        public void DeleteMaterial(Guid id) 
        {
            _context.Materials.Remove(_context.Materials.SingleOrDefault(a => a.ID == id));
            _context.SaveChanges();
        }
    }
}
