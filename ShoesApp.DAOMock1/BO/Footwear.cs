﻿using INF148151_148140.ShoesApp.Core;
using INF148151_148140.ShoesApp.Intefaces;


namespace INF148151_148140.ShoesApp.DAOMock1.BO
{
    public class Footwear : IFootwear
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public IProducer Producer { get; set; }
        public FootwearType Type { get; set; }
    }
}
