﻿namespace WuwaTrackerBackend.Models
{
    public class Flower
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
}
