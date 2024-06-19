using Riok.Mapperly.Abstractions;
using WuwaTrackerBackend.Models;
using WuwaTrackerBackend.DTOs;

namespace WuwaTrackerBackend.Mappers
{
    [Mapper]
    public static partial class CharacterMapper
    {
        public static partial CharacterDTO ToDto(Character character);
        public static partial Character ToModel(CharacterDTO characterDTO);
    }
}
