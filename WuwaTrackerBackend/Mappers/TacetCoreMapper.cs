using Riok.Mapperly.Abstractions;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Mappers
{
    [Mapper]
    public static partial class TacetCoreMapper
    {
        public static partial TacetCoreDTO ToDTO(TacetCore tacetCore);
        public static partial TacetCore ToModel(TacetCoreDTO tacetCoreDTO);
    }
}
