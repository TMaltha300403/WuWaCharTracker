using Microsoft.AspNetCore.Mvc;
using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterContainer _characterContainer;

        public CharacterController(ICharacterContainer characterContainer)
        {
            _characterContainer = characterContainer;
        }

        [HttpGet(nameof(GetAllCharacters))]
        public ActionResult<IEnumerable<CharacterDTO>> GetAllCharacters()
        {
            return Ok(_characterContainer.GetAll());
        }

        [HttpGet(nameof(GetCharacter))]
        public ActionResult<IEnumerable<CharacterDTO>> GetCharacter(Guid id)
        {
            return Ok(_characterContainer.GetCharacter(id));
        }

        [HttpPost(nameof(CreateCharacter))]
        public ActionResult CreateCharacter(CharacterDTO dto)
        {
            dto.ID = Guid.NewGuid();
            _characterContainer.CreateCharacter(dto);
            return Ok();
        }

        [HttpDelete(nameof(DeleteCharacter))]
        public ActionResult DeleteCharacter(Guid id)
        {
            _characterContainer.DeleteCharacter(id);
            return Ok();
        }

        [HttpPost(nameof(UpdateCharacter))]
        public ActionResult UpdateCharacter(CharacterDTO dto)
        {
            _characterContainer.UpdateCharacter(dto);
            return Ok();
        }
    }
}
