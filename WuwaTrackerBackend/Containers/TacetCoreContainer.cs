
using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Mappers;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.Repositories;

namespace WuwaTrackerBackend.Containers
{
    public class TacetCoreContainer : ITacetCoreContainer
    {
        private readonly ITacetCoreRepository _tacetcoreRepository;

        public TacetCoreContainer(ITacetCoreRepository tacetcoreRepository)
        {
            _tacetcoreRepository = tacetcoreRepository;
        }

        public void CreateTacetCore(TacetCoreDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            TacetCore tacetcoreModel = TacetCoreMapper.ToModel(dto);
            _tacetcoreRepository.CreateTacetCore(tacetcoreModel);
        }

        public void DeleteTacetCore(Guid id)
        {
            _tacetcoreRepository.DeleteTacetCore(id);
        }

        public IEnumerable<TacetCoreDTO> GetAll()
        {
            return _tacetcoreRepository.GetAll()
                .Select(TacetCoreMapper.ToDTO);
        }

        public void UpdateTacetCore(TacetCoreDTO dto)
        {
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), null))
            {
                throw new ArgumentException("Invalid input data");
            }

            _tacetcoreRepository.UpdateTacetCore(TacetCoreMapper.ToModel(dto));
        }
    }
}
