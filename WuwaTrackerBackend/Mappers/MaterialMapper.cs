using Riok.Mapperly.Abstractions;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Mappers
{
    [Mapper]
    public static partial class MaterialMapper
    {
        public static partial MaterialDTO ToDto(Material material);
        public static partial Material ToModel(MaterialDTO materialDTO);
    }
}
