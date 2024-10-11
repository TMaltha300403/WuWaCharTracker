using Riok.Mapperly.Abstractions;
using System.Security;
using WuwaTrackerBackend.DTOs;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.Mappers
{
    [Mapper]
    public static partial class LocationMapper
    {
        public static partial LocationDTO ToDto(Location location);
        public static partial Location ToModel(LocationDTO location);
    }
}
