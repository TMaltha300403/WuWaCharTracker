using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Mappers;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.Repositories;

namespace WuwaTrackerBackend.Containers
{
    public class MaterialContainer : IMaterialContainer
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialContainer(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public void createMaterial(MaterialDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            Material materialModel = MaterialMapper.ToModel(dto);
            _materialRepository.CreateMaterial(materialModel);
        }

        public void DeleteMaterial(Guid id)
        {
            _materialRepository.DeleteMaterial(id);
        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            return _materialRepository.GetAll()
                .Select(MaterialMapper.ToDto);
        }

        public void UpdateMaterial(MaterialDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            _materialRepository.UpdateMaterial(MaterialMapper.ToModel(dto));
        }
    }
}
