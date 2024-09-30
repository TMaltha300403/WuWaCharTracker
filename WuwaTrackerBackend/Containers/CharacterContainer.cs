using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Mappers;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.Repositories;

namespace WuwaTrackerBackend.Containers
{
    public class CharacterContainer : ICharacterContainer
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterContainer(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public IEnumerable<CharacterDTO> GetAll()
        {
            return _characterRepository.GetAll()
                .Select(CharacterMapper.ToDto);
        }

        public IEnumerable<CharacterDTO> GetCharacter(Guid id)
        {
            return _characterRepository.GetCharacter(id)
                .Select(CharacterMapper.ToDto);
        }

        public void CreateCharacter(CharacterDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            Character characterModel = CharacterMapper.ToModel(dto);
            _characterRepository.CreateCharacter(characterModel);
        }

        public void DeleteCharacter(Guid id) 
        {
            _characterRepository.DeleteCharacter(id);
        }

        public void UpdateCharacter(CharacterDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            _characterRepository.UpdateCharacter(CharacterMapper.ToModel(dto));
        }

        public int[] UpgradeCount(int upgradeLevel)
        {
            int[] amountNeeded;
            switch(upgradeLevel)
            {
                case 0:
                    amountNeeded = [4, 12, 12, 4, 46, 60];
                    break;
                case 1:
                    amountNeeded = [0, 12, 12, 4, 46, 60];
                    break;
                case 2:
                    amountNeeded = [0, 8, 12, 4, 43, 56];
                    break;
                case 3:
                    amountNeeded = [0, 0, 12, 4, 37, 48];
                    break;
                case 4:
                    amountNeeded = [0, 0, 8, 4, 28, 36];
                    break;
                case 5:
                    amountNeeded = [0, 0, 0, 4, 16, 20];
                    break;
                case 6:
                    amountNeeded = [0, 0, 0, 0, 0, 0];
                    break;
                default:
                    amountNeeded = [0, 0, 0, 0, 0, 0];
                    break;
            }
            return amountNeeded;
        }
    }
}
