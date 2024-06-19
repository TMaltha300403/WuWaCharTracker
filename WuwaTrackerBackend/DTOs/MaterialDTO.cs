using System.ComponentModel.DataAnnotations;

namespace WuwaTrackerBackend.DTOs
{
    public class MaterialDTO
    {
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameLow { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameMedium { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameHigh { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameHighest { get; set; }
    }
}
