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
    }
}
