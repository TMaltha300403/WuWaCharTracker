using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly WuwaContext _context;

        public CharacterRepository(WuwaContext context)
        {
            _context = context;
        }

        public void CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void DeleteCharacter(Guid id)
        {
            _context.Characters.Remove(_context.Characters.SingleOrDefault(a => a.ID == id));
            _context.SaveChanges();
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters
                .ToArray();
        }

        public void UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            _context.SaveChanges ();
        }
    }
}
