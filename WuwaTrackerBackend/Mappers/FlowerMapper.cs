using Riok.Mapperly.Abstractions;
using System.Security;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Mappers
{
    [Mapper]
    public static partial class FlowerMapper
    {
        public static partial FlowerDTO ToDto(Flower flower);
        public static partial Flower ToModel(FlowerDTO flowerDTO);
    }
}
