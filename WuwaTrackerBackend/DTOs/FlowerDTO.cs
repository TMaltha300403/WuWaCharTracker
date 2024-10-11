using System.ComponentModel.DataAnnotations;
using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.DTOs
{
    public class FlowerDTO
    {
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
}
