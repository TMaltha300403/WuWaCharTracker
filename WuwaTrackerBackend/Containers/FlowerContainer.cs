using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Mappers;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.Repositories;


namespace WuwaTrackerBackend.Containers
{
    public class FlowerContainer : IFlowerContainer
    {
        private readonly IFlowerRepository _flowerRepository;

        public FlowerContainer(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }

        public IEnumerable<FlowerDTO> GetAll()
        {
            return _flowerRepository.GetAll()
                .Select(FlowerMapper.ToDto);
        }

        public void CreateFlower(FlowerDTO dto)
        {

            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            Flower flowerModel = FlowerMapper.ToModel(dto);
            _flowerRepository.CreateFlower(flowerModel);
        }

        public void DeleteFlower(Guid id)
        {
            _flowerRepository.DeleteFlower(id);
        }

        public void UpdateFlower(FlowerDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            _flowerRepository.UpdateFlower(FlowerMapper.ToModel(dto));
        }

        public IEnumerable<FlowerDTO> GetFlower(Guid id)
        {
            return _flowerRepository.GetFlower(id)
                .Select(FlowerMapper.ToDto);
        }
    }
}
