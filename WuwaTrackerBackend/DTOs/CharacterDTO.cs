using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.DTOs
{
    public class CharacterDTO
    {
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public FlowerDTO FlowerType { get; set; }
        [Required]
        public MaterialDTO MaterialType { get; set; }
        [Required]
        public TacetCoreDTO TacetCoreType { get; set; }
    }
}
