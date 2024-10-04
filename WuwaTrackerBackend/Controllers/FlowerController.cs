using Microsoft.AspNetCore.Mvc;
using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerContainer _flowerContainer;

        public FlowerController(IFlowerContainer flowerContainer)
        {
            _flowerContainer = flowerContainer;
        }

        [HttpGet(nameof(GetAllFlowers))]
        public ActionResult<IEnumerable<FlowerDTO>> GetAllFlowers()
        {
            return Ok(_flowerContainer.GetAll());
        }

        [HttpPost(nameof(CreateFlower))]
        public ActionResult CreateFlower(FlowerDTO dto)
        {
            dto.ID = Guid.NewGuid();
            _flowerContainer.CreateFlower(dto);
            return Ok();
        }

        [HttpDelete(nameof(DeleteFlower))]
        public ActionResult DeleteFlower(Guid id)
        {
            _flowerContainer.DeleteFlower(id);
            return Ok();
        }

        [HttpPost(nameof(UpdateFlower))]
        public ActionResult UpdateFlower(FlowerDTO dto)
        {
            _flowerContainer.UpdateFlower(dto);
            return Ok();
        }

        [HttpGet(nameof(GetFlower))]
        public ActionResult<IEnumerable<FlowerDTO>> GetFlower(Guid id)
        {
            return Ok(_flowerContainer.GetFlower(id));
        }
    }
}
