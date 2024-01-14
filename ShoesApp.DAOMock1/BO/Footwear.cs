using ShoesApp.Core;
using ShoesApp.Intefaces;


namespace ShoesApp.DAOMock1.BO
{
    public class Footwear : IFootwear
    {
        public int ID { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public IProducer Producer { get; set; }
        public FootwearType Type { get; set; }
    }
}
