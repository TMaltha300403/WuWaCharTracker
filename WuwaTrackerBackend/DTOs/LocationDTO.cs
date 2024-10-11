using WuwaTrackerBackend.Models;

namespace WuwaTrackerBackend.DTOs
{
    public class LocationDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Flower> Flowers { get; set; }
    }
}
