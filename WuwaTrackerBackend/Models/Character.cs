using System.ComponentModel.DataAnnotations.Schema;

namespace WuwaTrackerBackend.Models
{
    public class Character
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(FlowerID))]
        public Guid FlowerID { get; set; }
        [ForeignKey(nameof(TacetCoreID))]
        public Guid TacetCoreID { get; set; }
        [ForeignKey(nameof(MaterialID))]
        public Guid MaterialID { get; set; }
    }
}
