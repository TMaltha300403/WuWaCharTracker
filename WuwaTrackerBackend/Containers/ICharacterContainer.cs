using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Containers
{
    public interface ICharacterContainer
    {
        IEnumerable<CharacterDTO> GetAll();
        void CreateCharacter(CharacterDTO character);
        void UpdateCharacter(CharacterDTO character);
        void DeleteCharacter(Guid id);
        IEnumerable<CharacterDTO> GetCharacter(Guid id);
        int[] UpgradeCount(int upgradeLevel);
    }
}
