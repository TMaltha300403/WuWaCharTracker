using Microsoft.AspNetCore.Mvc;
using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialContainer _materialContainer;

        public MaterialController(IMaterialContainer materialContainer)
        {
            _materialContainer = materialContainer;
        }

        [HttpGet(nameof(GetAllMaterials))]
        public ActionResult<IEnumerable<MaterialDTO>> GetAllMaterials()
        {
            return Ok(_materialContainer.GetAll());
        }

        [HttpPost(nameof(CreateMaterial))]
        public ActionResult CreateMaterial(MaterialDTO dto) 
        {
            dto.ID = Guid.NewGuid();
            _materialContainer.createMaterial(dto);
            return Ok();
        }

        [HttpDelete(nameof(DeleteMaterial))]
        public ActionResult DeleteMaterial(Guid id)
        {
            _materialContainer.DeleteMaterial(id);
            return Ok();
        }

        [HttpPost(nameof(UpdateMaterial))]
        public IActionResult UpdateMaterial(MaterialDTO dto)
        {
            _materialContainer.UpdateMaterial(dto);
            return Ok();
        }
    }
}
