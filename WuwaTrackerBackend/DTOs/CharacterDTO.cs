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
        public Guid FlowerID { get; set; }
        [Required]
        public Guid MaterialID { get; set; }
        [Required]
        public Guid TacetCoreID { get; set; }
    }
}
