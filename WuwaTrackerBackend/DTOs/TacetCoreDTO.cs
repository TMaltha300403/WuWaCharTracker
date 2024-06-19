using System.ComponentModel.DataAnnotations;

namespace WuwaTrackerBackend.DTOs
{
    public class TacetCoreDTO
    {
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
