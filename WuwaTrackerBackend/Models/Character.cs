namespace WuwaTrackerBackend.Models
{
    public class Character
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Flower FlowerType { get; set; }
        public TacetCore TacetCoreType { get; set; }
        public Material MaterialType { get; set; }
    }
}
