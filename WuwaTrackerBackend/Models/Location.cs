namespace WuwaTrackerBackend.Models
{
    public class Location
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Flower> Flowers { get; set; }
    }
}
