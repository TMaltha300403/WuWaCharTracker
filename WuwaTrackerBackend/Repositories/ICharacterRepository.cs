using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Repositories
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetAll();
        void CreateCharacter(Character character);
        void UpdateCharacter(Character character);
        void DeleteCharacter(Guid id);
    }
}

