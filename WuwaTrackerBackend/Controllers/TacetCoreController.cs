using Microsoft.AspNetCore.Mvc;
using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacetCoreController : ControllerBase
    {
        private readonly ITacetCoreContainer _tacetCoreContainer;

        public TacetCoreController(ITacetCoreContainer tacetCoreContainer)
        {
            _tacetCoreContainer = tacetCoreContainer;
        }

        [HttpGet(nameof(GetAllTacetCores))]
        public ActionResult<IEnumerable<TacetCoreDTO>> GetAllTacetCores()
        {
            return Ok(_tacetCoreContainer.GetAll());
        }

        [HttpPost(nameof(CreateTacetCore))]
        public ActionResult CreateTacetCore(TacetCoreDTO dto)
        {
            dto.ID = Guid.NewGuid();
            _tacetCoreContainer.CreateTacetCore(dto);
            return Ok();
        }

        [HttpDelete(nameof(DeleteTacetCore))]
        public ActionResult DeleteTacetCore(Guid id)
        {
            _tacetCoreContainer.DeleteTacetCore(id);
            return Ok();
        }

        [HttpPost(nameof(UpdateTacetCore))]
        public ActionResult UpdateTacetCore(TacetCoreDTO dto)
        {
            _tacetCoreContainer.UpdateTacetCore(dto);
            return Ok();
        }
    }
}
